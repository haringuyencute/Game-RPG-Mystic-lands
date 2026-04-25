using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MessageShopController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text buttonText;
    public Text shopOwnerMessage;
    public Color32 messageOff;
    public Color32 messageOn;
    public GameObject[] shopUI;
    [HideInInspector]
    public int shopNum = 0;

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonText.color = messageOn;
        PlayerMove.canMove = false;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonText.color = messageOff;
        PlayerMove.canMove = true;
    }

    private void Start()
    {
        shopOwnerMessage.text = "Hello " + SaveScript.pname + " how can i help you?";
    }
    public void Message1()
    {
        shopOwnerMessage.text = "not much going on around here";
    }
    public void Message2()
    {
        shopOwnerMessage.text = "select items from the list";
        shopUI[shopNum].SetActive(true);
        if (shopNum < 6)
        {
            shopUI[shopNum].GetComponent<ShopController>().UpdateGold();

        }
    }
    private void Update()
    {
        if (PlayerMove.canMove && PlayerMove.moving)
        {
            if (shopUI != null)
            {
                shopUI[shopNum].SetActive(false);
            }
        }
    }
}
