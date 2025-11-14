using UnityEngine;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [Header("Audio Sources")]
    public AudioSource bgSource;     // For background music
    public AudioSource sfxSource;    // For sound effects

    [Header("Volumes")]
    [Range(0f, 1f)] public float bgVolume = 1f;
    [Range(0f, 1f)] public float sfxVolume = 1f;

    [Header("Sound Library (Optional)")]
    public SoundLibrary soundLibrary;   // ScriptableObject

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        if (bgSource != null) bgSource.loop = true;
        SoundManager.Instance.PlayBGMusic("BG");
    }

    // ---------------------------------------------------------
    //  PLAY ONE SHOT (SFX)
    // ---------------------------------------------------------
    public void PlayOneShot(AudioClip clip)
    {
        if (clip == null || sfxSource == null) return;

        sfxSource.PlayOneShot(clip, sfxVolume);
    }

    public void PlayOneShot(string clipName)
    {
        if (soundLibrary == null) return;

        AudioClip clip = soundLibrary.GetClipByName(clipName);
        PlayOneShot(clip);
    }

    // ---------------------------------------------------------
    //  PLAY BACKGROUND MUSIC
    // ---------------------------------------------------------
    public void PlayBGMusic(AudioClip clip)
    {
        if (clip == null || bgSource == null) return;

        if (bgSource.clip == clip && bgSource.isPlaying)
            return;

        bgSource.clip = clip;
        bgSource.volume = bgVolume;
        bgSource.Play();
    }

    public void PlayBGMusic(string clipName)
    {
        if (soundLibrary == null) return;

        AudioClip clip = soundLibrary.GetClipByName(clipName);
        PlayBGMusic(clip);
    }

    // ---------------------------------------------------------
    //  CONTROL METHODS
    // ---------------------------------------------------------
    public void StopBG()
    {
        if (bgSource != null)
            bgSource.Stop();
    }

    public void PauseBG()
    {
        if (bgSource != null)
            bgSource.Pause();
    }

    public void ResumeBG()
    {
        if (bgSource != null)
            bgSource.UnPause();
    }

    public void SetSFXVolume(float volume)
    {
        sfxVolume = volume;
        sfxSource.volume = sfxVolume;
    }

    public void SetBGVolume(float volume)
    {
        bgVolume = volume;
        bgSource.volume = bgVolume;
    }
}
