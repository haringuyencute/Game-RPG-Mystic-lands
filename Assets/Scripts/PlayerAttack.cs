using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private GameObject objToDestroy;
    public int damageAmt;
    public bool canDamage = true;
    private WaitForSeconds damagePause = new WaitForSeconds(0.5f);
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("crate"))
        {
            other.transform.gameObject.GetComponentInParent<ChestController>().Particles();
            objToDestroy = other.transform.parent.gameObject;
            Destroy(other.transform.gameObject);
            StartCoroutine(WaitForDestroy());
        }
        if(other.CompareTag("enemy") && canDamage)
        {
            canDamage = false;
            other.transform.gameObject.GetComponent<EnemyMove>().enemyHealth -= damageAmt + SaveScript.weaponIncrease + SaveScript.strengthIncrease;
            StartCoroutine(ResetDamage());
        }
        if(other.CompareTag("spider") && canDamage)
        {
            canDamage = false;
            other.transform.gameObject.GetComponent<EnemyMove>().enemyHealth -= (damageAmt/8) + SaveScript.weaponIncrease + SaveScript.strengthIncrease;
            StartCoroutine(ResetDamage());
        }
        if(other.CompareTag("dragon") && canDamage)
        {
            canDamage = false;
            other.transform.gameObject.GetComponent<DragonController>().enemyHealth -= (damageAmt/8) + SaveScript.weaponIncrease + SaveScript.strengthIncrease;
            StartCoroutine(ResetDamage());
        }
    }
    IEnumerator WaitForDestroy()
    {
        yield return new WaitForSeconds(3);
        Destroy(objToDestroy);
    }
    IEnumerator ResetDamage()
    {
        yield return damagePause;
        canDamage = true;
    }

}
