using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelection : MonoBehaviour
{
    public int weaponNumber;
    AudioManager audioManager;
    private void Start()
    {
        audioManager = FindFirstObjectByType<AudioManager>();
    }
    public void ChooseWeapon()
    {
        SaveScript.weaponChoice = weaponNumber;
        SaveScript.weaponChange = true;
        SaveScript.carryingWeapon = true;
        audioManager.PlaySFX(audioManager.selectWeaponClip);
    }
}
