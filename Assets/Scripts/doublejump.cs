using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doublejump : MonoBehaviour
{
    public CharacterController2D controller;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            controller.canJumpTwice = true;
            GameObject.Destroy(this.gameObject);
        }
    }
}
