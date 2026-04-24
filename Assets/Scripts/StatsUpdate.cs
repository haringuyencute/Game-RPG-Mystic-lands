using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsUpdate : MonoBehaviour
{
    public Text nameText;
    public Text currencyText;
    public Text killAmtText;
    public Image strengthBar;
    public Image manaBar;
    public Image staminaBar;
    public GameObject[] weaponButtons;
    public GameObject inventoryObj;
    public bool updateWeapons = true;
    public GameObject[] items;
    // Start is called before the first frame update
    void Start()
    {
        nameText.text = SaveScript.pname;
        if (SaveScript.pchar == 1 || SaveScript.pchar == 3 || SaveScript.pchar == 5)
        {
            items[0].SetActive(true);
        }
        else
        {
            items[1].SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        currencyText.text = InventoryItems.gold.ToString();
        killAmtText.text = SaveScript.killAmt.ToString();
        strengthBar.fillAmount = SaveScript.strengthAmt;
        manaBar.fillAmount = SaveScript.manaPowerAmt;
        staminaBar.fillAmount = SaveScript.staminaPowerAmt;

        if (updateWeapons == true)
        {
            for (int i = 0; i < weaponButtons.Length; i++)
            {
                if (inventoryObj.GetComponent<InventoryItems>().weapons[i] == true)
                {
                    weaponButtons[i].SetActive(true);
                }
            }
        }
        if (this.isActiveAndEnabled)
        {
            updateWeapons = false;
        }
    }
}
