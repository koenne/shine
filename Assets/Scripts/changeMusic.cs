using System.Collections.Generic;
using UnityEngine;

public class changeMusic : MonoBehaviour
{
    public AudioSource audioSource;
    public List<AudioClip> audioClips;
    public bool changeSong = true;
    private int lastSong = 0;
    private int r = 0;
    // Update is called once per frame
    void Update()
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
