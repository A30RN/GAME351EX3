using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Music Tracks")]
    public AudioSource defaultTrack;
    public AudioSource suspenseTrack;
    public AudioSource fightTrack;

    [Header("Sound Effects")]
    public AudioSource footstepSound;
    public AudioSource gunshotSound;
    public AudioSource explosionSound;
    public AudioSource windAmbience;
    public AudioSource banditTaunts;

    private AudioSource currentTrack;

    void Start()
    {
        PlayDefault();
    }

    public void PlayDefault()
    {
        defaultTrack.enabled = true;
        suspenseTrack.enabled = false;
        fightTrack.enabled = false;
    }

    public void PlaySuspense()
    {
        defaultTrack.enabled = false;
        suspenseTrack.enabled = true;
        fightTrack.enabled = false;
    }

    public void PlayFight()
    {
        defaultTrack.enabled = false;
        suspenseTrack.enabled = false;
        fightTrack.enabled = true;
    }
}
