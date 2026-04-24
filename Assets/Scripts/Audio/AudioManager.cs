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

    [Header("UI Clip")]
    public AudioClip bookOpenClip;
    public AudioClip selectClip;
    public AudioClip buyClip;
    public AudioClip createPotionClip;
    public AudioClip pickupClip;
    public AudioClip chestClip;
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
        }
        else if (musicState == 2)
        {
            audioPlayer.clip = tavernClipLoop;
        }
        else if( musicState == 3)
        {
            audioPlayer.clip = battleClipLoop;
        }
        audioPlayer.Play();
    }
    public void PlaySFX(AudioClip clip)
    {
        UISound.clip = clip;
        UISound.Play();
    }
}
