using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItems : MonoBehaviour
{
    public GameObject inventoryMenu;
    public GameObject openBook;
    public GameObject closedBook;
    public GameObject potionBook;

    public Image[] emptySlots;
    public Sprite[] icons;
    public Sprite emptyIcon;
    public AudioManager audioManager;

    public static int redMushroom = 0;
    public static int purpleMushroom = 0;
    public static int brownMushroom = 0;
    public static int blueFlower = 0;
    public static int redFlower = 0;
    public static int root = 0;
    public static int leafDew = 0;
    public static int dragonEgg = 0;
    public static int redPotion = 0;
    public static int bluePotion = 0;
    public static int greenPotion = 0;
    public static int purplePotion = 0;
    public static int bread = 0;
    public static int cheese = 0;
    public static int meat = 0;
    public static bool key = true;
    public static int gold = 30000;

    public static int newIcon = 0;
    public static bool iconUpdate = false;
    private int max;
    public GameObject theCanvas;
    [HideInInspector]
    public string entry;
    public string[] items;
    [HideInInspector]
    public int currentID = 0;
    [HideInInspector]
    public int checkAmt = 0;
    private int maxItem;
    private int maxEmptySlot;

    public Image[] UISlots;
    public Sprite[] magicIcons;
    public Sprite[] spellIcons;
    public KeyCode[] keyCodes;
    public bool setMagic = false;
    public bool setSpell = false;
    [HideInInspector]
    public int selected = 0;
    public int[] magicAttack;

    public GameObject[] magicParticles;
    public Image manaBar;

    // Start is called before the first frame update
    void Start()
    {
        inventoryMenu.SetActive(false);
        openBook.SetActive(false);
        closedBook.SetActive(true);
        potionBook.SetActive(false);
        max = emptySlots.Length;
        maxItem = items.Length;
        maxEmptySlot = emptySlots.Length;

        // Temp 
        redMushroom = 0;
        purpleMushroom = 0 ;
        brownMushroom = 0 ;
        blueFlower = 0 ;
        redFlower = 0 ;

    }

    // Update is called once per frame
    void Update()
    {
        if (iconUpdate)
        {
            for (int i = 0; i < max; i++)
            {
                if (emptySlots[i].sprite == emptyIcon)
                {
                    max = i;
                    emptySlots[i].sprite = icons[newIcon];
                    emptySlots[i].transform.gameObject.GetComponent<HintMessage>().objectType = newIcon;
                }
            }
            StartCoroutine(Reset());
        }
        if (setMagic)
        {
            for (int i = 0; i < UISlots.Length; i++)
            {
                if (Input.GetKeyDown(keyCodes[i]))
                {
                    setMagic = false;
                    UISlots[i].sprite = magicIcons[selected];
                    magicAttack[i] = selected;
                    theCanvas.GetComponent<CreatePotion>().Removed(selected);
                }
            }
        }
        if (setSpell)
        {
            setMagic = false;
            for (int i = 0; i < UISlots.Length; i++)
            {
                if (Input.GetKeyDown(keyCodes[i]))
                {
                    setSpell = false;
                    UISlots[i].sprite = spellIcons[selected];
                    magicAttack[i] = selected + 6;
                    
                }
            }
        }
        if(Input.anyKey && Time.timeScale == 1)
        {
            for(int i = 0;i < UISlots.Length;i++)
            {
                if (Input.GetKeyDown(keyCodes[i]))
                {
                    if(UISlots[i].sprite != emptyIcon)
                    {
                        if(SaveScript.manaAmt > 0.1f)
                        {
                            Instantiate(magicParticles[magicAttack[i]], SaveScript.spawnPoint.transform.position, SaveScript.spawnPoint.transform.rotation);
                            audioManager.PlaySFX(audioManager.magicClips[magicAttack[i]]);
                        }
                        if (magicAttack[i] < 6 && SaveScript.manaAmt > 0.1f)
                        {
                            UISlots[i].sprite = emptyIcon;
                        }

                    }
                }
            }
        }
        manaBar.fillAmount = SaveScript.manaAmt;
    }

    public void CheckStatics()
    {
        for(int i = 0; i < maxItem; i ++)
        {
            if(i == currentID)
            {
                maxItem = i;
                entry = items[i];
                checkAmt = System.Convert.ToInt32(typeof(InventoryItems).GetField(entry).GetValue(null));
                checkAmt--;
                typeof(InventoryItems).GetField(entry).SetValue(null,checkAmt);
                if(checkAmt == 0)
                {
                    RemoveIcon(i);
                }
            }
        }
        maxItem = items.Length;
    }

    public void RemoveIcon(int iconTyoe)
    {
        for(int i = 0; i < maxEmptySlot; i++)
        {
            if (emptySlots[i].sprite == icons[iconTyoe])
            {
                maxEmptySlot = i;
                emptySlots[i].sprite = icons[0];
                emptySlots[i].transform.gameObject.GetComponent<HintMessage>().objectType = 0;
            }
        }
        maxEmptySlot = emptySlots.Length;
    }

    public void OpenMenu()
    {
        inventoryMenu.SetActive(true);
        openBook.SetActive(true);
        closedBook.SetActive(false);
        audioManager.PlaySFX(audioManager.bookOpenClip);
        SaveScript.theTarget = null;
        Time.timeScale = 0;
    }
    public void CloseMenu()
    {
        inventoryMenu.SetActive(false);
        openBook.SetActive(false);
        closedBook.SetActive(true);
        Time.timeScale = 1;
    }

    public void OpenPotionBook()
    {
        potionBook.SetActive(true);
    }
    public void ClosePotionBook()
    {
        theCanvas.GetComponent<CreatePotion>().value = 0;
        theCanvas.GetComponent<CreatePotion>().thisValue = 0;
        potionBook.SetActive(false);
    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(0.1f);
        iconUpdate =false;
        max = emptySlots.Length;
    }
}
