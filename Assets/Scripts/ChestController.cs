using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestController : MonoBehaviour
{
    private Animator anim;
    public int goldAmount = 50;
    public GameObject particleEffect;
    public GameObject spawnPoint;
    public GameObject canvasText;
    public Text goldAmtInChestText;
    public float speed = 1f;
    public GameObject mainCam;
    private int goldDisplay;
    public AudioManager audioManager;
    public bool crate = false;


    // Start is called before the first frame update
    void Start()
    {
        if(crate == false)
        {
            anim = GetComponent<Animator>();

        }
        canvasText.SetActive(false);
        goldDisplay = goldAmount;
    }

    private void Update()
    {
        if(canvasText.activeSelf == true)
        {
            canvasText.transform.Translate(Vector3.up*speed*Time.deltaTime); ;
            goldAmtInChestText.text = goldDisplay.ToString();
            canvasText.transform.LookAt(mainCam.transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (crate != false)
        {
            if (other.CompareTag("Player"))
            {
                if (InventoryItems.key)
                {
                    anim.SetTrigger("open");
                    InventoryItems.gold += goldAmount;
                    goldAmount = 0;
                    audioManager.PlaySFX(audioManager.chestClip);
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(crate == false)
        {
            if (other.CompareTag("Player"))
            {
                if (InventoryItems.key)
                {
                    anim.SetTrigger("close");
                }
            }
        }
    }
    public void DestroyChest()
    {
        Destroy(this.gameObject);
    }
    public void Particles()
    {
        Instantiate(particleEffect, spawnPoint.transform.position,spawnPoint.transform.rotation);
        canvasText.SetActive(true);
        if (crate == true)
        {
            InventoryItems.gold += goldAmount;
            goldAmount = 0;
            audioManager.PlaySFX(audioManager.chestClip);
        }
    }
}

