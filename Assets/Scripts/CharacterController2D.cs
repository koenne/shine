using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
	[SerializeField] private float m_JumpForce = 400f;							// Amount of force added when the player jumps.
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;	// How much to smooth out the movement
	[SerializeField] private bool m_AirControl = true;							// Whether or not a player can steer while jumping;
	[SerializeField] private LayerMask m_WhatIsGround;							// A mask determining what is ground to the character
	[SerializeField] private Transform m_GroundCheck;							// A position marking where to check if the player is grounded.
    [SerializeField] private playerAnimator animatorControl;
	[SerializeField] private AudioSource jumpSound;
	public int jumpcount =0;
	public bool canJumpTwice = false;
    public float k_GroundedRadius = .1f; // Radius of the overlap circle to determine if grounded
	public bool m_Grounded;            // Whether or not the player is grounded.
	private Rigidbody2D m_Rigidbody2D;
	private bool m_FacingRight = true;  // For determining which way the player is currently facing.
	private Vector3 m_Velocity = Vector3.zero;
	public NewPlayerMovement newPlayerMovement;
	private Vector3 targetVelocity = new Vector2(0,0);
	private float velocityX = 0;
	public bool isGravityReversed = false;
	private playerAnimator animator;
	private groundCheckMove groundCheckMove;
    private bool hasDoubleJumped = false;
    public bool hasDash; //Haha

    // Dash variables
    [SerializeField] private float dashSpeed = 20f;
    [SerializeField] private float dashDuration = 0.2f;
    [SerializeField] private float dashCooldown = 1f;

    private bool isDashing = false;
    private float dashTimeLeft;
    private float lastDashTime = -Mathf.Infinity;
    private int dashDirection = 0;
    private bool canDashAgain;

    [Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }


	private void Awake()
	{
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        animator = FindObjectOfType<playerAnimator>();
        groundCheckMove = FindObjectOfType<groundCheckMove>();

        if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();
	}
    private void Update()
    {
        bool wasGrounded = m_Grounded;
        m_Grounded = false;

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {

                m_Grounded = true;
                canDashAgain = true;
                //jumpcount = 0;
                if (!wasGrounded)
                {
                    OnLandEvent.Invoke();
                }


            }
        }
        if (m_Grounded)
        {
            hasDoubleJumped = false; // Reset double jump state
            animatorControl.setFall(false);
            animatorControl.setJumping(false);
            animatorControl.setJump2(false);
            animatorControl.setDash(false);
            velocityX = 0;
        }
        else
		{
            animatorControl.setFall(true);
        }
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            m_Rigidbody2D.velocity = new Vector2(dashDirection * dashSpeed, 0f);
            dashTimeLeft -= Time.fixedDeltaTime;

            if (dashTimeLeft <= 0f)
            {
                isDashing = false;
            }
            if (!newPlayerMovement.dash)
            {
                isDashing = false;
            }
            return; // Skip normal movement while dashing
        }
    }



    public void Move(float move, bool jump, bool dash)
    {
        // Only control the player if grounded or airControl is turned on
        if ((m_Grounded || m_AirControl) && !isDashing)
        {
            animatorControl.setRunning(true);

            // Move the character in the direction they are facing
            Vector2 moveDirection = transform.right * move * 10f; // Forward direction
            targetVelocity = new Vector2(moveDirection.x + velocityX, m_Rigidbody2D.velocity.y);

            // Smooth movement
            m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

            // Flip logic if you're still handling facing manually
            if (move > 0 && !m_FacingRight)
            {
                Flip();
            }
            else if (move < 0 && m_FacingRight)
            {
                Flip();
            }
        }
        else
        {
            animatorControl.setRunning(false);
        }

        // Jump Logic
        if (jump)
        {
                if (m_Grounded)
                {
                    PerformJump(); //  Ground jump
                }
                else if (canJumpTwice && !hasDoubleJumped)
                {
                    hasDoubleJumped = true;
                    PerformJump(); //  Air jump
                }
        }
        if (dash && !isDashing && Time.time >= lastDashTime + dashCooldown && hasDash && !m_Grounded && canDashAgain)
        {
            canDashAgain = false;
            isDashing = true;
            dashTimeLeft = dashDuration;
            lastDashTime = Time.time;
            dashDirection = m_FacingRight ? 1 : -1;
            animatorControl.setDash(true);
        }
    }

    private void PerformJump()
    {
        m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, 0);
        m_Rigidbody2D.AddForce(transform.up * m_JumpForce, ForceMode2D.Impulse);
        jumpSound.Play();
        animatorControl.setJumping(true);
        m_Grounded = false;
    }


    private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	public void doubleJumpActivate()
	{
		canJumpTwice = !canJumpTwice;
	}

	public void setVelocityY(float newVelocity)
	{
		m_Rigidbody2D.AddForce(new Vector2(0, newVelocity * 30));
	}
    public void setVelocityX(float newVelocity)
    {
        //Debug.Log(newVelocity);
        velocityX = newVelocity;
    }
	public void changeJumpForce()
	{
		m_JumpForce *= -1;
	}
	public void GravityChange(bool isReverse)
	{
        if (isReverse && GetComponent<Rigidbody2D>().gravityScale != -1.5f)
        {
            GetComponent<Rigidbody2D>().gravityScale = -1.5f;
            animator.gravityChange(true);
            groundCheckMove.changeGravity(true);
            changeJumpForce();
            isGravityReversed = true;
        }
        else if (GetComponent<Rigidbody2D>().gravityScale != 1.5f && !isReverse)
        {
            GetComponent<Rigidbody2D>().gravityScale = 1.5f;
            animator.gravityChange(false);
            groundCheckMove.changeGravity(false);
            changeJumpForce();
            isGravityReversed = false;
        }
    }
}
