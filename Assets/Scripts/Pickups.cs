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
    public bool key = false;
    public bool coins = false;
    public bool isDragon = false;
    public AudioManager audioManager;

    private void Start()
    {
        audioManager = FindFirstObjectByType<AudioManager>();
        if (coins)
        {
            Destroy(gameObject, 5);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            audioManager.PlaySFX(audioManager.pickupClip);
            if (redMushroom)
            {
                if(InventoryItems.redMushrooms == 0)
                {
                    DisplayIcons();
                }
                InventoryItems .redMushrooms++;
                Destroy(gameObject);
            }
            else if (purpleMushroom)
            {
                if (InventoryItems.purpleMushrooms == 0)
                {
                    DisplayIcons();
                }
                InventoryItems.purpleMushrooms++;
                Destroy(gameObject);
            }
            else if (brownMushroom)
            {
                if (InventoryItems.brownMushrooms == 0)
                {
                    DisplayIcons();
                }
                InventoryItems.brownMushrooms++;
                Destroy(gameObject);
            }
            else if (blueFlower)
            {
                if (InventoryItems.blueFlowers == 0)
                {
                    DisplayIcons();
                }
                InventoryItems.blueFlowers++;
                Destroy(gameObject);
            }
            else if (redFlower)
            {
                if (InventoryItems.redFlowers == 0)
                {
                    DisplayIcons();
                }
                InventoryItems.redFlowers++;
                Destroy(gameObject);
            }
            else if (key)
            {
                DisplayIcons();
                InventoryItems.key = true;
                Destroy(gameObject);
            }
            else if (coins)
            {
                if (isDragon)
                {
                    InventoryItems.gold += 500;
                    Destroy(gameObject);
                }
                else
                {
                    InventoryItems.gold += Random.Range(5, 250);
                    Destroy(gameObject);
                }

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
