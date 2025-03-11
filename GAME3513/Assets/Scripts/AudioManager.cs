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
    public AudioSource banditDeath;
    public AudioSource kicks;

    void Start()
    {
        PlayDefault();

        footstepSound.enabled = false;
        gunshotSound.enabled = false;
        explosionSound.enabled = false;
        windAmbience.enabled = false;
        banditDeath.enabled = false;
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

    //Audio clips

    public void PlayFootStep()
    {
        footstepSound.Play();

        footstepSound.enabled = true;
        gunshotSound.enabled = false;
        explosionSound.enabled = false;
        windAmbience.enabled = false;
        banditDeath.enabled = false;
        kicks.enabled = false;
    }

    public void PlayGunShot()
    {
        gunshotSound.Play();

        footstepSound.enabled = false;
        gunshotSound.enabled = true;
        explosionSound.enabled = false;
        windAmbience.enabled = false;
        banditDeath.enabled = false;
        kicks.enabled = false;
    }

    public void PlayExplosion()
    {
        explosionSound.Play();

        footstepSound.enabled = false;
        gunshotSound.enabled = false;
        explosionSound.enabled = true;
        windAmbience.enabled = false;
        banditDeath.enabled = false;
        kicks.enabled = false;
    }

    public void PlayWind()
    {
        windAmbience.Play();

        footstepSound.enabled = false;
        gunshotSound.enabled = false;
        explosionSound.enabled = false;
        windAmbience.enabled = true;
        banditDeath.enabled = false;
        kicks.enabled = false;
    }

    public void PlayDeath()
    {
        banditDeath.Play();

        footstepSound.enabled = false;
        gunshotSound.enabled = false;
        explosionSound.enabled = false;
        windAmbience.enabled = false;
        banditDeath.enabled = true;
        kicks.enabled = false;
    }

    public void PlayKick()
    {
        kicks.Play();

        footstepSound.enabled = false;
        gunshotSound.enabled = false;
        explosionSound.enabled = false;
        windAmbience.enabled = false;
        banditDeath.enabled = false;
        kicks.enabled = true;
    }
}
