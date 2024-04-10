using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeMusic : MonoBehaviour
{
    public AudioSource audioSource;
    public List<AudioClip> audioClips;
    public bool changeSong = true;
    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying || changeSong)
        {
            int r = Random.Range(0, audioClips.Count);
            AudioClip clip = audioClips[r];
            audioSource.clip = clip;
            audioSource.Play();
            changeSong = false;
        }
    }
}
