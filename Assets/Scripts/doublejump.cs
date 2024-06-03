using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doublejump : MonoBehaviour
{
    public CharacterController2D controller;
    public AudioSource itemSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            controller.canJumpTwice = true;
            AudioSource.PlayClipAtPoint(itemSound.clip, this.gameObject.transform.position);
            GameObject.Destroy(this.gameObject);
        }
    }
}
