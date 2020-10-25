using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class DelayPlayAudio : MonoBehaviour, IDelay
{
    private AudioSource audio;

    [SerializeField] private AudioClip clip;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    public void Fire()
    {
        if (clip != null) // if the clip has been set in the inspector
            audio.clip = clip;

        if (audio.clip != null) //checking if the AudioSource har a clip. it can be a the clip set in script or a clip assigned to the audiosource in the inspector.
            audio.Play();
        else
            Debug.LogError("the AudioSource on " +gameObject.name+ " is null");
    }
}
