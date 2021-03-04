using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPalyer : MonoBehaviour
{
    private static AudioPalyer instance = null;
    public AudioClip audioClip;
    // Start is called before the first frame update
    void Awake()
    {
        // if the singleton hasn't been initialized yet
        if (instance != null)
        {
            Destroy(this);
            return;//Avoid doing anything else
        }

        instance = this;
        PlayAudio();
    }
    void PlayAudio()
    {
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.playOnAwake = true;
        audioSource.loop = true;
        audioSource.Play();
    }

}
