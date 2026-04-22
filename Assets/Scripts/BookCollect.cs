using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookCollect : MonoBehaviour
{
    public GameObject magicUI;
    public GameObject spellsUI;
    public bool magicBook = false;
    public bool spellbook = false;

    private bool magicCollected = false;
    private bool spellCollected = false;

    // Start is called before the first frame update
    void Start()
    {
        spellsUI.SetActive(false);
        magicUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(magicBook && !magicCollected)
            {
                magicUI.SetActive(true);
                magicCollected = true;
            }
            else if(spellbook && !spellCollected)
            {
                spellsUI.SetActive(true) ;
                spellCollected = true;
            }
        }
    }
}
