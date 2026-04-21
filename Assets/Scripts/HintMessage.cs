using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class HintMessage : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject hintBox;
    public Text message;
    private bool displaying = true;
    private bool overIcon = false;
    public int objectType = 0;

    private Vector3 screenPoint;
    public void OnPointerEnter(PointerEventData eventData)
    {
        overIcon = true;
        if(displaying)
        {
            hintBox.SetActive(true);
            screenPoint.x = Input.mousePosition.x + 500;
            screenPoint.y = Input.mousePosition.y;
            screenPoint.z = 1f;
            hintBox.transform.position = Camera.main.ScreenToWorldPoint(screenPoint);
            MessageDisplay();

        }
    }
    private void Start()
    {
        hintBox.SetActive(false);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        overIcon=false;
        hintBox.SetActive(false);
    }

    private void Update()
    {
        if (overIcon)
        {
            if (Input.GetMouseButtonDown(0))
            {
                displaying = false;
                hintBox.SetActive(false );
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            displaying = true;
        }
    }
    void MessageDisplay()
    {
        if(objectType == 0)
        {
            message.text = "Empty";

        }
        if (objectType == 1)
        {
            message.text = InventoryItems.redMushroom.ToString() + " red mushrooms to be used in potions";
        }
        if (objectType == 2)
        {
            message.text = InventoryItems.purpleMusroom.ToString() + " purple mushrooms to be used in potions";
        }
        if (objectType == 3)
        {
            message.text = InventoryItems.brownMushroom.ToString() + " brown mushrooms to be used in potions";
        }
        if (objectType == 4)
        {
            message.text = InventoryItems.blueFlower.ToString() + " blue flowers to be used in potions";
        }
        if (objectType == 5)
        {
            message.text = InventoryItems.redFlower.ToString() + " red flowers to be used in potions";
        }
        if (objectType == 6)
        {
            message.text = InventoryItems.root.ToString() + " roots to be used in potions";
        }
        if (objectType == 7)
        {
            message.text = InventoryItems.leafDew.ToString() + " leaf dew to be used in potions";
        }
        if (objectType == 8)
        {
            message.text = InventoryItems.key.ToString() + " key to open chests";
        }
        if (objectType == 9)
        {
            message.text = InventoryItems.dragonEgg.ToString() + " dragon eggs to be used in potions";
        }
        if (objectType == 10)
        {
            message.text = InventoryItems.bluePotion.ToString() + " blue potion to be used in potions";
        }
        if (objectType == 11)
        {
            message.text = InventoryItems.purplePotion.ToString() + " purple potion to be used in potions";
        }
        if (objectType == 12)
        {
            message.text = InventoryItems.greenPotion.ToString() + " green potion to be used in potions";
        }
        if (objectType == 13)
        {
            message.text = InventoryItems.redPotion.ToString() + " red potion to be used in potions";
        }
        if (objectType == 14)
        {
            message.text = InventoryItems.bread.ToString() + " bread to replenish health";
        }
        if (objectType == 15)
        {
            message.text = InventoryItems.cheese.ToString() + " cheese to replenish health";
        }
        if (objectType == 16)
        {
            message.text = InventoryItems.meat.ToString() + " meat to replenish health";
        }
    }
}
