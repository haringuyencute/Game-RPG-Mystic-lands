using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleMove : MonoBehaviour
{
    public GameObject target;
    public GameObject obj;
    public float speed = 5f;
    public float lifeTime = 1.5f;
    public bool enemySeeker = false;
    public bool nonMoving = false;
    public bool followPlayer = false;
    private GameObject playerObj;
    private GameObject targetSave;
    public float manacost = 0.05f;
    public bool invisibility = false;

    private void Start()
    {
        targetSave = SaveScript.theTarget;
        playerObj = GameObject.FindGameObjectWithTag("Player");
        if(invisibility == true)
        {
            SaveScript.invisible = true;
        }
    }
    private void Update()
    {
        if (target != null)
        {
            transform.position = Vector3.LerpUnclamped(transform.position, target.transform.position, speed * Time.deltaTime);
        }
        if (enemySeeker)
        {
            if (targetSave != null)
            {
                transform.position = Vector3.LerpUnclamped(transform.position, targetSave.transform.position, speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
        }
        if (nonMoving)
        {
            if (targetSave != null)
            {
                transform.position = targetSave.transform.position;
            }
            else
            {
                Destroy(obj);
            }
        }
        if(followPlayer)
        {
            transform.position = playerObj.transform.position;
            lifeTime = 100;
            if(SaveScript.manaAmt <= 0.02)
            {
                Destroy(obj);
            }
        }
        SaveScript.manaAmt -= manacost*Time.deltaTime;
        Destroy(obj, lifeTime);
    }
}
