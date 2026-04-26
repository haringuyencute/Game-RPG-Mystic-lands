using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookCollect : MonoBehaviour
{
    public GameObject magicUI;
    public GameObject spellsUI;
    public bool magicBook = false;
    public bool spellsBook = false;
    public GameObject spellsMessage;
    public GameObject magicMessage;
    public AudioManager audioManager;
    public static  bool magicCollected = false;
    public static bool spellsCollected = false;

    // Start is called before the first frame update
    void Start()
    {
        if (magicBook == true)
        {
            magicUI.SetActive(false);
            magicMessage.SetActive(false);
        }
        if (spellsBook == true)
        {
            spellsUI.SetActive(false);
            spellsMessage.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (magicBook == true)
            {
                if (magicCollected == false)
                {
                    magicUI.SetActive(true);
                    magicCollected = true;
                    StartCoroutine(DisplayMessageUI());
                }
            }
            if (spellsBook == true)
            {
                if (spellsCollected == false)
                {
                    spellsUI.SetActive(true);
                    spellsCollected = true;
                    StartCoroutine(DisplayMessageUI());
                }
            }
        }
    }
    IEnumerator DisplayMessageUI()
    {
        yield return new WaitForSeconds(0.5f);
        audioManager.PlaySFX(audioManager.bookOpenClip);
        if (magicBook == true)
        {
            magicMessage.SetActive(true);
        }
        if (spellsBook == true)
        {
            spellsMessage.SetActive(true);
        }
        yield return new WaitForSeconds(2);
        if (magicBook == true)
        {
            magicMessage.SetActive(false);
        }
        if (spellsBook == true)
        {
            spellsMessage.SetActive(false);
        }
        Destroy(gameObject);
    }
}
