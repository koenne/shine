using System.Collections.Generic;
using UnityEngine;

public class changeMusic : MonoBehaviour
{
    public AudioSource audioSource;
    public List<AudioClip> audioClips;
    public bool changeSong = true;
    private int lastSong = 0;
    private int r = 0;
    private void Start()
    {
        foreach (AudioClip clip in audioClips)
        {
            clip.LoadAudioData();
        }
    }
    void FixedUpdate()
    {
        if (!audioSource.isPlaying || changeSong)
        {
            while(r == lastSong)
            {
                r = Random.Range(0, audioClips.Count);
            }
            lastSong = r;
            AudioClip clip = audioClips[r];
            audioSource.clip = clip;
            audioSource.Play();
            changeSong = false;
        }
    }
}
