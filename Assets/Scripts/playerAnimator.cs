using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimator : MonoBehaviour
{
    public Animator animator;
    public bool isFalling = false;
    public AudioSource walk1;
    private float time = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("isRunning", false);
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            if (!isFalling)
            {
                setRunning(true);
                time -= Time.deltaTime;
                if (time < 0)
                {
                    time = 0.4f;
                    float pitch = Random.Range(0.5f, 2.5f);
                    walk1.pitch = pitch;
                    walk1.Play();
                }

            }
            else
            {
                setRunning(false);
            }

        }
        else
        {
            setRunning(false);
        }

        if (Input.GetButtonDown("Jump") || Input.GetKey(KeyCode.Space))
        {
            setJumping(true);
        }
    }
    public void setRunning(bool running)
    {
        if (running)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }
    public void setJumping(bool jumping)
    {
        if (jumping)
        {
            if (!animator.GetBool("isJumping"))
            {
            animator.SetBool("isJumping", true);
            isFalling = true;
            }
        }
        if(!isFalling)
        {
            animator.SetBool("isJumping", false);
        }
    }
    public void setFall(bool fall)
    {
        if (fall)
        {
            animator.SetBool("isFalling", true);
            isFalling = true;
        }
        else
        {
            animator.SetBool("isFalling", false);
            isFalling = false;
            animator.SetBool("isJumping", false);
        }
    }
}
