using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool jump2 = false;
    public bool canMove = true;
    int jumpcount;

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
            if (Input.GetButtonDown("Jump"))
            {
                if(jumpcount == 1)
                {
                    jump2 = true;
                }
                else
                {
                    jump = true;
                }
                jumpcount++;
            }
        }

    }

    void FixedUpdate()
    {
        if (canMove)
        {
            // Move our character
            controller.Move(horizontalMove * Time.fixedDeltaTime, jump, jump2);
            jump = false;
            jump2 = false;
        }

    }
    public void died(bool yes)
    {
        canMove = yes;
    }
    public void resetJump()
    {
        jumpcount = 0;
    }
}
