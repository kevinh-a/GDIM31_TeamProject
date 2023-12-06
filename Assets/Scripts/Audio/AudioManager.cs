using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource SFXAudio;

    [SerializeField]
    private AudioSource MusicAudio;

    private static AudioManager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(this);
        }
    }

    public static void PlaySFX(AudioClip clip)
    {
        instance.SFXAudio.PlayOneShot(clip);
    }

    public static void PlayMusic(AudioClip clip)
    {
        instance.MusicAudio.Stop();
        instance.MusicAudio.clip = clip;
        instance.MusicAudio.Play();
    }
}
