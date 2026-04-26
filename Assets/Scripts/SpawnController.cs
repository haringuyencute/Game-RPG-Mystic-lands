using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject[] enemies;
    public Transform[] spawnPoints;
    public GameObject audioManager;
    private bool canSpawn = true;
    private bool enemyTrigger = true;
    public bool reSpawner = true;
    // Update is called once per frame
    void Update()
    {
        if (SaveScript.enemiesOnScreen <= 0)
        {
            if (canSpawn == false && enemyTrigger == false)
            {
                enemyTrigger = true;
                if (reSpawner == true)
                {
                    canSpawn = true;
                }
                audioManager.GetComponent<AudioManager>().musicState = 1;
                audioManager.GetComponent<AudioManager>().canPlay = true;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (canSpawn == true)
            {
                enemyTrigger = false;
                canSpawn = false;
                for (int i = 0; i < enemies.Length; i++)
                {
                    Debug.Log(i);
                    Instantiate(enemies[i], spawnPoints[i].position,spawnPoints[i].rotation);
                    SaveScript.enemiesOnScreen++;
                    audioManager.GetComponent<AudioManager>().musicState = 3;
                    audioManager.GetComponent<AudioManager>().canPlay = true;
                }
            }
        }
    }
}
