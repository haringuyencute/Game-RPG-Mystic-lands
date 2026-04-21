using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingTrigger : MonoBehaviour
{
    public GameObject roof;
    public GameObject props;
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
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            roof.SetActive(true);
            props.SetActive(false);
        }
    }
}
