using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public GameObject thisOutLineEnemy;
    private bool outLineOn = false;
    // Start is called before the first frame update
    void Start()
    {
        thisOutLineEnemy.GetComponent<Outline>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!outLineOn)
        {
            outLineOn = true;
            if(SaveScript.theTarget == thisOutLineEnemy)
            {
                thisOutLineEnemy.GetComponent<Outline>().enabled = true;
            }
        }
        if(outLineOn)
        {
            if(SaveScript.theTarget != thisOutLineEnemy)
            {
                thisOutLineEnemy.GetComponent<Outline>().enabled = false;
                outLineOn = false;
            }
        }
    }
}
