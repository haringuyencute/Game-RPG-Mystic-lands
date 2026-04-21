using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    public GameObject shopUI;
    //Arrays
    public int[] amt;
    public int[] cost;
    public int[] iconNum;
    public int[] inventoryItems;
    public Text[] itemAmtText;
    public Text currencyText;
    private Text compare;
    public bool tavern = false;
    private int max = 0;
    private bool canClick = true;
    // Start is called before the first frame update
    void Start()
    {
        max = itemAmtText.Length;
        currencyText.text = InventoryItems.gold.ToString();
    }
    public void CloseShop()
    {
        shopUI.SetActive(false);
        PlayerMove.canMove = true;
    }
    public void BuyButton()
    {
        if(!canClick) { return; }
        for (int i = 0; i < max; i++)
        {
            if (itemAmtText[i] == compare)
            {
                max = i;
                if (amt[i] > 0)
                {
                    if (tavern == true)
                    {
                        UpdateTavernAmt();
                    }
                    else
                    {
                        UpdateWizardAmt();
                    }
                    if (InventoryItems.gold >= cost[i])
                    {
                        if (inventoryItems[i] == 0)
                        {
                            InventoryItems.newIcon = iconNum[i];
                            InventoryItems.iconUpdate = true;
                        }
                        InventoryItems.gold -= cost[i];
                        if (tavern == true)
                        {
                            SetTavernAmt(i);
                        }
                        else
                        {
                            SetWizardAmt(i);
                        }
                    }
                }
            }
        }
    }


    void UpdateTavernAmt()
    {
        inventoryItems[0] = InventoryItems.bread;
        inventoryItems[1] = InventoryItems.cheese;
        inventoryItems[2] = InventoryItems.meat;
    }
    void UpdateWizardAmt()
    {
        inventoryItems[0] = InventoryItems.redPotion;
        inventoryItems[1] = InventoryItems.purplePotion;
        inventoryItems[2] = InventoryItems.bluePotion;
        inventoryItems[3] = InventoryItems.greenPotion;
        inventoryItems[4] = InventoryItems.dragonEgg;
        inventoryItems[5] = InventoryItems.root;
        inventoryItems[6] = InventoryItems.leafDew;
    }

    public void UpdateGold()
    {
        currencyText.text = InventoryItems.gold.ToString();
    }
    void SetTavernAmt(int item)
    {
        if (item == 0)
        {
            InventoryItems.bread++;
        }
        if (item == 1)
        {
            InventoryItems.cheese++;
        }
        if (item == 2)
        {
            InventoryItems.meat++;
        }
        amt[item]--;
        itemAmtText[item].text = amt[item].ToString();
        currencyText.text = InventoryItems.gold.ToString();
        max = itemAmtText.Length;
    }

    private void SetWizardAmt(int item)
    {
        if (item == 0)
        {
            InventoryItems.redPotion++;
        }
        if (item == 1)
        {
            InventoryItems.purplePotion++;
        }
        if (item == 2)
        {
            InventoryItems.bluePotion++;
        }
        if (item == 3)
        {
            InventoryItems.greenPotion++;
        }
        if (item == 4)
        {
            InventoryItems.dragonEgg++;
        }
        if (item == 5)
        {
            InventoryItems.root++;
        }
        if (item == 6)
        {
            InventoryItems.leafDew++;
        }
        amt[item]--;
        itemAmtText[item].text = amt[item].ToString();
        currencyText.text = InventoryItems.gold.ToString();
        max = itemAmtText.Length;
    }
    public void Bread()
    {
        compare = itemAmtText[0];
        Check(0);
    }
    public void Cheese()
    {
        compare = itemAmtText[1];
        Check(1);
    }
    public void Meat()
    {
        compare = itemAmtText[2];
        Check(2);
    }
    public void RedPotion()
    {
        compare = itemAmtText[0];
        Check(0);
    }
    public void PurplePotion()
    {
        compare = itemAmtText[1];
        Check(1);
    }
    public void BluePotion()
    {
        compare = itemAmtText[2];
        Check(2);
    }
    public void GreenPotion()
    {
        compare = itemAmtText[3];
        Check(3);
    }
    public void DragonEgg()
    {
        compare = itemAmtText[4];
        Check(4);
    }
    public void Root()
    {
        compare = itemAmtText[5];
        Check(5);
    }
    public void DewLeaf()
    {
        compare = itemAmtText[6];
        Check(6);
    }
    void Check(int b)
    {
        if (amt[b] > 0)
        {
            canClick = true;
        }
        else
        {
            canClick = false;
        }
    }
    void CheckWizardShop(int b)
    {
        if (amt[b] > 0)
        {
            canClick = true;
        }
        else
        {
            canClick = false;
        }
    }
}

