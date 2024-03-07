using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("---------Audio Source---------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("---------Audio Clip---------")]
    public AudioClip backgroundMusic;
    public AudioClip leadObtained;
    public AudioClip interruption;
    public AudioClip begin;
    public AudioClip gameOver;

    private void Start()
    {
        musicSource.clip = backgroundMusic;
        musicSource.loop = true;
        musicSource.Play();
    }

}

