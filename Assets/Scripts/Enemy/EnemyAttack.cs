using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float damageAmt = 0.006f;
    private WaitForSeconds delayTime = new WaitForSeconds(1);
    private bool canAttack = true;
    //private AudioSource audioPlayer;
    private void Start()
    {
        //audioPlayer = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (canAttack == true && SaveScript.invulnerable == false)
            {
                canAttack = false;
                SaveScript.playerHealth -= damageAmt - SaveScript.armorValue;
               // audioPlayer.Play();
                StartCoroutine(ResetDamage());
            }
        }
    }
    IEnumerator ResetDamage()
    {
        yield return delayTime;
        canAttack = true;
    }
}
