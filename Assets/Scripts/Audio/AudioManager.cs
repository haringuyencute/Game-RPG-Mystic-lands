using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioPlayer;
    public GameObject UISoundObj;
    public AudioSource UISound;

    [Header("Loop Clip")]
    public AudioClip bgClipLoop;
    public AudioClip tavernClipLoop;
    public AudioClip battleClipLoop;
    public AudioClip blacksmithLoop;
    public AudioClip wizardLoop;

    [Header("UI Clip")]
    public AudioClip bookOpenClip;
    public AudioClip selectClip;
    public AudioClip buyClip;
    public AudioClip createPotionClip;
    public AudioClip pickupClip;
    public AudioClip chestClip;
    public AudioClip selectWeaponClip;
    public AudioClip[] magicClips;
    [HideInInspector]
    public bool canPlay = true;
    public int musicState = 1;
    // Start is called before the first frame update
    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
        UISound = UISoundObj.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        StateSound();
    }
    public void StateSound()
    {

        if (!canPlay) { return; }
        canPlay = false;
        if (musicState == 1)
        {
            audioPlayer.clip = bgClipLoop;
            audioPlayer.volume = 0.6f;
        }
        else if (musicState == 2)
        {
            audioPlayer.clip = tavernClipLoop;
            audioPlayer.volume = 0.4f;
        }
        else if( musicState == 3)
        {
            audioPlayer.clip = battleClipLoop;
            audioPlayer.volume = 0.3f;
        }
        else if( musicState == 4)
        {
            audioPlayer.clip = blacksmithLoop;
            audioPlayer.volume = 0.4f;
        }
        else if( musicState == 5)
        {
            audioPlayer.clip = wizardLoop;
            audioPlayer.volume = 0.4f;
        }
        audioPlayer.Play();
    }
    public void PlaySFX(AudioClip clip)
    {
        UISound.clip = clip;
        UISound.Play();
    }
}
