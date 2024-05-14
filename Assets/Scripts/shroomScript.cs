using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class shroomScript : MonoBehaviour
{
    private float horizontal = 1f;
    private float speed = 0.5f;
    private Rigidbody2D rb;
    private playerSpikes playerSpikes;
    private float count = 0f;
    public Animator animator;
    private Vector3 startPos;
    public Rigidbody2D playerRB;
    public float jumpHeight;
    private float timer = 0f;
    private bool canMove = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
        playerSpikes = FindObjectOfType<playerSpikes>();
        playerRB = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        animator.gameObject.GetComponent<Animator>().enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Spikes"))
        {
            if (count > 0.15f)
            {
                speed *= -1;
                Flip();
            }
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            playerSpikes.enemyHit();
        }
        if (collision.gameObject.CompareTag("CameraTrigger"))
        {
            animator.gameObject.GetComponent<Animator>().enabled = true;
            rb.transform.position = startPos;
        }
    }
    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
    public void noGround()
    {
        if (count > 0.15f)
        {
            speed *= -1;
            Flip();
            count = 0;
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CameraTrigger"))
        {
                timer += Time.deltaTime;
                count += Time.deltaTime;
            if (canMove)
            {
                rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
            }
            else
            {

                if (timer <= 7f)
                {
                    if(timer < 0.5f)
                    {
                        animator.SetBool("isHit", false);
                    }
                    //Debug.Log(timer);
                }
                else
                {
                    animator.SetBool("isDone", true);
                    timer = 0;
                    canMove = true;
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CameraTrigger"))
        {
            rb.velocity = Vector3.zero;
            animator.gameObject.GetComponent<Animator>().enabled = false;
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //jumpHeight = -playerRB.velocity.y * 10;
            rb.velocity = new Vector2(0, 0);
            canMove = false;
            timer = 0;
            playerRB.velocity = new Vector2(playerRB.velocity.x, 0);
            playerRB.AddForce(new Vector2(0f, 500));
            animator.SetBool("isDone", false);
            animator.SetBool("isHit", true);
        }
    }
}
