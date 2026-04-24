using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyWeapon : MonoBehaviour
{
    public int weaponNumber;
    public int armorNumber;
    public int cost;
    public Text currencyText;
    public GameObject inventoryObj;
    AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        currencyText.text = InventoryItems.gold.ToString();
        audioManager = FindFirstObjectByType<AudioManager>();
    }
    public void BuyWeaponButton()
    {
        if (InventoryItems.gold >= cost)
        {
            InventoryItems.gold -= cost;
            inventoryObj.GetComponent<InventoryItems>().weapons[weaponNumber] =true;
            audioManager.PlaySFX(audioManager.buyClip);
            currencyText.text = InventoryItems.gold.ToString();
        }
    }
    public void BuyArmor()
    {
        if (InventoryItems.gold >= cost)
        {
            SaveScript.armor = armorNumber;
            SaveScript.changeArmor = true;
            InventoryItems.gold -= cost;
            audioManager.PlaySFX(audioManager.buyClip);
            currencyText.text = InventoryItems.gold.ToString();
        }
    }
}
