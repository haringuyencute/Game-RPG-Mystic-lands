using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTarget : MonoBehaviour
{
    public float speed = 1f;
    public bool rotator = false;
    public bool particleTarget = false;
    public int damageAmt = 30;
    public GameObject lastObj;

    // Update is called once per frame
    void Update()
    {
        if (rotator)
        {
            transform.Rotate(0, speed * Time.deltaTime, 0); ;
        }
        if (particleTarget)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy") || other.CompareTag("spider") && other.transform.gameObject != lastObj)
        {
            other.transform.gameObject.GetComponent<EnemyMove>().enemyHealth -= damageAmt;
            lastObj = other.transform.gameObject;
        }
        if (other.CompareTag("dragon") && other.transform.gameObject != lastObj)
        {
            other.transform.gameObject.GetComponent<DragonController>().enemyHealth -= damageAmt;
            lastObj = other.transform.gameObject;
        }
    }
}
