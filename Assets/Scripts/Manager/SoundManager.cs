using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    [Header("Music")]
    [SerializeField] private AudioClip musicClip;
    
    [Header("Sounds")]
    [SerializeField] private AudioClip attackClip;
    [SerializeField] private AudioClip dashClip;
    [SerializeField] private AudioClip impactClip;
    [SerializeField] private AudioClip coinClip;
    [SerializeField] private AudioClip itemClip;
    
    // public AudioClip MusicClip => musicClip;
    public AudioClip AttackClip => attackClip;
    public AudioClip ImpactClip => impactClip;
    public AudioClip CoinClip => coinClip;
    public AudioClip ItemClip => itemClip;
    public AudioClip DashClip => dashClip;

    private AudioSource musicAudioSource;
    private ObjectPooler soundObjectPooler;

    protected override void Awake()
    {
        soundObjectPooler = GetComponent<ObjectPooler>();
        musicAudioSource = GetComponent<AudioSource>();
        
        PlayMusic();
    }

    private void PlayMusic()
    {
        musicAudioSource.loop = true;
        musicAudioSource.clip = musicClip;
        musicAudioSource.volume = 0.2f;
        musicAudioSource.Play();
    }
    
    public void PlaySound(AudioClip clipToPlay, float volume)
    {
        GameObject audioPooled = soundObjectPooler.GetObjectFromPool();
        AudioSource audioSource = null;

        if (audioPooled != null)
        {
            audioPooled.SetActive(true);
            audioSource = audioPooled.GetComponent<AudioSource>();
        }

        audioSource.clip = clipToPlay;
        audioSource.volume = volume;
        audioSource.Play();

        StartCoroutine(ReturnToPool(audioPooled, clipToPlay.length + 1));
    }

    private IEnumerator ReturnToPool(GameObject objectPool, float delay)
    {
        yield return new WaitForSeconds(delay);
        objectPool.SetActive(false);
    }
}