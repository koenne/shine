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
		if (m_Grounded)
		{
            animatorControl.setFall(false);
            animatorControl.setJumping(false);
            animatorControl.setJump2(false);
            newPlayerMovement.resetJump();
			velocityX = 0;
        }
		else
		{
            animatorControl.setFall(true);
        }
    }

    private void FixedUpdate()
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
                if (!wasGrounded)
				{
					OnLandEvent.Invoke();
				}


            }
		}
	}


    public void Move(float move, bool jump, bool jump2)
    {
        // Only control the player if grounded or airControl is turned on
        if (m_Grounded || m_AirControl)
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
            if (canJumpTwice)
            {
                if (m_Grounded)
                {
                    jumpcount = 0;
                }
                if (jumpcount == 0)
                {
                    Debug.Log("jump one");
                    animatorControl.setFall(false);
                    animatorControl.setJump2(true);
                    m_Rigidbody2D.AddForce(transform.up * m_JumpForce, ForceMode2D.Impulse); // Apply jump force relative to player's rotation
                    m_Grounded = false;
                    jumpSound.Play();
                    animatorControl.setJumping(true);
                }
                else if (jumpcount == 1)
                {
                    Debug.Log("jump two");
                    m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, 0); ; // Reset vertical velocity before jumping
                    m_Rigidbody2D.AddForce(transform.up * m_JumpForce, ForceMode2D.Impulse);
                    m_Grounded = false;
                    jumpSound.Play();
                    animatorControl.setJumping(true);
                }
                jumpcount++;
            }
            else if (m_Grounded)
            {
                Debug.Log("Only Jump");
                jumpSound.Play();
                animatorControl.setJumping(true);
                m_Rigidbody2D.AddForce(transform.up * m_JumpForce, ForceMode2D.Impulse); // Relative jump force
                m_Grounded = false;
            }
        }
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
