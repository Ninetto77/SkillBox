using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager : MonoBehaviour
{
    [Header("Аудио")]
    [SerializeField] private AudioSource raidAudioSource;
    [SerializeField] private AudioSource peasantHiringAudioSource;
    [SerializeField] private AudioSource warriorHiringAudioSource;
    [SerializeField] private AudioSource audioClick;

    
    private UIManager _uIManager;
    private AudioListener audioListener;

    private void Start()
    {
        audioListener = GetComponent<AudioListener>();
        _uIManager = GetComponent<UIManager>(); 
    }
    public void ChangeSoundState()
    {
        if (AudioListener.volume != 0f)
        {
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = 1f;
        }
        _uIManager.ChangeSoundSprite();
    }

    public void PlayClickSound()
    {
        audioClick.Play();
    }
    public void PlayPeasantSound()
    {
        peasantHiringAudioSource.Play();
    }
    public void PlayWarriorSound()
    {
        warriorHiringAudioSource.Play();
    }
    public void PlayRaidSound()
    {
        raidAudioSource.Play();
    }
}
