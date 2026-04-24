using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelection : MonoBehaviour
{
    public int weaponNumber;
    //AudioManager audioManager;
    public void ChooseWeapon()
    {
        SaveScript.weaponChoice = weaponNumber;
        SaveScript.weaponChange = true;
        SaveScript.carryingWeapon = true;
       // audioManager.PlaySFX()
    }
}
