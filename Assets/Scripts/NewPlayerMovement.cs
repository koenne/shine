using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    public bool canMove = true;

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
            }
        }

    }

    void FixedUpdate()
    {
        if (canMove)
        {
            // Move our character
            controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
                jump = false;
        }

    }
    public void died(bool yes)
    {
        canMove = yes;
    }
}
