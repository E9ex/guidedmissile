using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    private AudioSource _audioSource;
    [SerializeField] private AudioClip radarsesi, targetlock, missilecarpti, missileateslendi;

    private void Awake()
    {
        instance = this;
        _audioSource = GetComponent<AudioSource>();
    }
    public void Radarsesi()
    {
        _audioSource.PlayOneShot(radarsesi);
    }
    public void Targetlock()
    {
        _audioSource.PlayOneShot(targetlock);
    }
    public void MissileLaunched()
    {
        _audioSource.PlayOneShot(missileateslendi);
    }
    public void MissileHit()
    {
        _audioSource.PlayOneShot(missilecarpti);
    }
    
}
