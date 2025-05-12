using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewPlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    public bool jump = false;
    public bool canMove = true;
    public GameObject menu;
    private bool menubool = false;
    private Rigidbody2D playerRB;

    private void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(playerRB.velocity.x);
        if (canMove)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (menubool)
            {
                menu.SetActive(false);
                menubool= false;
            }
            else
            {
                menu.SetActive(true);
                menubool = true;
            }
        }

    }

    void FixedUpdate()
    {
        if (MovementAllowed(canMove))
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
    public void resetFully()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    private bool MovementAllowed(bool canMove)
    {
        if (!canMove) return false;
        return true;
    }
}
