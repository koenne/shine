using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossMusicScript : MonoBehaviour
{
    public bool starting = false;
    public AudioSource normaMusic;
    public AudioSource bulletMusic;
    public Animator animator;
    public blueWitchScript blueWitch;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            starting = true;
            animator.SetBool("Start", true);
            normaMusic.volume = 0;
            bulletMusic.volume = 1;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            starting = false;
            animator.SetBool("Start", false);
            bulletMusic.volume = 0;
            normaMusic.volume = 1;
            blueWitch.shootTimer = 2f;
            blueWitch.shootTimer2 = 2.125f;
        }
    }
}
