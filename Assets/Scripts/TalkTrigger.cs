using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkTrigger : MonoBehaviour
{
    public GameObject messageBox;
    public int tavernNumber = 0;
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            messageBox.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            messageBox.GetComponentInChildren<MessageShopController>().shopNum = tavernNumber;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            messageBox.SetActive(false);
        }
    }
}
