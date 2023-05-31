using System;
using System.Collections.Generic;
using UnityEngine;

public enum SoundType
{
    Radar = 0,
    TargetLock = 1,
    MissileHit = 2,
    MissileFire = 3
    
}

[Serializable]
public class Sound
{
    public AudioClip audioClip;
    public SoundType soundType;
    public float volume = 1.0f;
}

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    private AudioSource _audioSource;
    [SerializeField] private AudioClip radarsesi, targetlock, missilecarpti, missileateslendi;

    [SerializeField] List<Sound> sounds = new List<Sound>();

    private void Awake()
    {
        instance = this;
        _audioSource = GetComponent<AudioSource>();
    }
    public void Radarsesi()
    {
        PlaySound(SoundType.Radar);
    }
    public void Targetlock()
    {
        PlaySound(SoundType.TargetLock);
    }
    public void MissileLaunched()
    {
        PlaySound(SoundType.MissileFire);
    }
    public void MissileHit()
    {
        PlaySound(SoundType.MissileHit);
    }

    public Sound GetSound(SoundType soundType)
    {
        foreach (var sound in sounds)
        {
            if (soundType == sound.soundType)
                return sound;
        }
        return null;
    }

    public void PlaySound(SoundType soundType)
    {
        var sound = GetSound(soundType);
        if(sound == null) return;
        
        _audioSource.volume = sound.volume;
        _audioSource.PlayOneShot(sound.audioClip);
    }
    
}
