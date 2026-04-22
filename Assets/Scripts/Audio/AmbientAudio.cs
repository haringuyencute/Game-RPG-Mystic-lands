using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientAudio : MonoBehaviour
{
    private  AudioSource audioSource;
    public WaitForSeconds waitTime = new WaitForSeconds(4);

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(PlaySoundAmbient());
    }

    IEnumerator PlaySoundAmbient()
    {
        yield return waitTime;
        audioSource.Play();
        StartCoroutine(PlaySoundAmbient());
    }
}
