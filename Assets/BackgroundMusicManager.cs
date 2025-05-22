using UnityEngine;

public class BackgroundMusicManager : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip moldavianClip;
    public AudioClip japoneseClip;
    public AudioClip franceAudioClip;

    private void Awake()
    {
        SetMoldavian();
    }

    public void SetJaponese() 
    {
        if (audioSource.clip == japoneseClip && audioSource.isPlaying) return; 
        audioSource.clip = japoneseClip;
        audioSource.Play();
    }

    public void SetMoldavian() 
    {
        if (audioSource.clip == moldavianClip && audioSource.isPlaying) return;
        audioSource.clip = moldavianClip;
        audioSource.Play();
    }

    public void SetFrance() 
    {
        if (audioSource.clip == franceAudioClip && audioSource.isPlaying) return;
        audioSource.clip = franceAudioClip;
        audioSource.Play();
    }
}
