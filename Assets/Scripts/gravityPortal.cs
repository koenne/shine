using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class gravityPortal : MonoBehaviour
{
    public bool isReverse;
    private GameObject player;
    public bool isFlipped;
    private playerAnimator animator;
    private groundCheckMove groundCheckMove;
    private CharacterController2D controller;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = FindObjectOfType<playerAnimator>();
        groundCheckMove = FindObjectOfType<groundCheckMove>();
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
            if(isReverse && player.GetComponent<Rigidbody2D>().gravityScale != -1.5f)
            {
                player.GetComponent<Rigidbody2D>().gravityScale = -1.5f;
                animator.gravityChange(true);
                groundCheckMove.changeGravity(true);
                controller.changeJumpForce();
            }
            else if(player.GetComponent<Rigidbody2D>().gravityScale != 1.5f && !isReverse)
            {
                player.GetComponent<Rigidbody2D>().gravityScale = 1.5f;
                animator.gravityChange(false);
                groundCheckMove.changeGravity(false);
                controller.changeJumpForce();
            }

        }
    }
}
