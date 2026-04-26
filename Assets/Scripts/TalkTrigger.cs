using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkTrigger : MonoBehaviour
{
    public GameObject messageBox;
    public int tavernNumber = 0;
    public string answer;
    public GameObject question;
    private bool haveRead = false;
    private GameObject miniMapView;
    private GameObject miniMapCompass;
    private GameObject inventoryObj;

    private void Start()
    {
        inventoryObj = GameObject.Find("InventoryCanvas");
        miniMapView = GameObject.FindGameObjectWithTag("minimapItem");
        miniMapCompass = GameObject.FindGameObjectWithTag("compass");
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            messageBox.SetActive(true);
            miniMapView.SetActive(false);
            miniMapCompass.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            messageBox.GetComponentInChildren<MessageShopController>().shopNum = tavernNumber;
            for (int i = 0; i < inventoryObj.GetComponent<InventoryItems>().messages.Length; i++)
            {
                if (answer == inventoryObj.GetComponent<InventoryItems>().messages[i].text)
                {
                    haveRead = true;
                }
            }
            if (haveRead == false)
            {
                haveRead = false;
                question.GetComponent<MessageShopController>().shopMessage = answer;
            }
            else if (haveRead == true)
            {
                question.GetComponent<MessageShopController>().shopMessage = "not much going on around here";
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            messageBox.SetActive(false);
            miniMapView.SetActive(true);
            miniMapCompass.SetActive(true);
        }
    }
}
