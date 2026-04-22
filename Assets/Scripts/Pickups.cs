using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    public int number;
    public bool redMushroom =false;
    public bool purpleMushroom = false;
    public bool brownMushroom = false;
    public bool blueFlower = false;
    public bool redFlower = false;
    public AudioManager audioManager;

    private void Start()
    {
        audioManager = FindFirstObjectByType<AudioManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            audioManager.PlaySFX(audioManager.pickupClip);
            if (redMushroom)
            {
                if(InventoryItems.redMushroom == 0)
                {
                    DisplayIcons();
                }
                InventoryItems.redMushroom++;
                Destroy(gameObject);
            }
            else if (purpleMushroom)
            {
                if (InventoryItems.purpleMushroom == 0)
                {
                    DisplayIcons();
                }
                InventoryItems.purpleMushroom++;
                Destroy(gameObject);
            }
            else if (brownMushroom)
            {
                if (InventoryItems.brownMushroom == 0)
                {
                    DisplayIcons();
                }
                InventoryItems.brownMushroom++;
                Destroy(gameObject);
            }
            else if (blueFlower)
            {
                if (InventoryItems.blueFlower == 0)
                {
                    DisplayIcons();
                }
                InventoryItems.blueFlower++;
                Destroy(gameObject);
            }
            else if (redFlower)
            {
                if (InventoryItems.redFlower == 0)
                {
                    DisplayIcons();
                }
                InventoryItems.redFlower++;
                Destroy(gameObject);
            }
            else
            {
                DisplayIcons();
                Destroy(gameObject);
            }
        }
    }
    void DisplayIcons()
    {
        InventoryItems.newIcon = number;
        InventoryItems.iconUpdate = true;
    }
}
