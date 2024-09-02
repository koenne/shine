using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class gravityPortal : MonoBehaviour
{
    public bool isReverse;
    private GameObject player;
    public bool isFlipped;
    private CharacterController2D controller;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        controller = FindObjectOfType<CharacterController2D>();
        if(isFlipped)
        {
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            changeGravity();
        }
    }
    public void changeGravity()
    {
        if (isReverse && player.GetComponent<Rigidbody2D>().gravityScale != -1.5f)
        {
            controller.GravityChange(true);
        }
        else if (player.GetComponent<Rigidbody2D>().gravityScale != 1.5f && !isReverse)
        {
            controller.GravityChange(false);
        }
    }
}
