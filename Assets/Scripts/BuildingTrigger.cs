using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingTrigger : MonoBehaviour
{
    public GameObject roof;
    public GameObject props;
    public AudioManager audioManager;
    public bool tavern = true;
    public bool blacksmith = false;
    public bool wizard = false;
    void Start()
    {
        roof.SetActive(true);
        props.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            roof.SetActive(false);
            props.SetActive(true);
            if (tavern)
            {
                audioManager.musicState = 2;
                audioManager.canPlay = true;
            }
            if (wizard)
            {
                audioManager.musicState = 4;
                audioManager.canPlay = true;
            }
            if (blacksmith)
            {
                audioManager.musicState = 5;
                audioManager.canPlay = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            roof.SetActive(true);
            props.SetActive(false);
            audioManager.musicState = 1;
            audioManager.canPlay = true;
        }
    }
}
