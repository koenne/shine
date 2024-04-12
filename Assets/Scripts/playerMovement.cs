using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 3f;
    private float jumpingPower = 6f;
    private bool isFacingRight = true;
    public bool isGrounded = true;
    public int jumpAmount = 0;
    public Animator animator;
    private float lastY;
    private bool isStill;

    private Rigidbody2D rb;
    public AudioSource jump;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator.SetBool("isRunning",false);
        lastY = gameObject.transform.position.y;

    }
    void Update()
    {
        checkUpOrDown();
        moving();
        jumping();
        Flip();
    }
    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    void checkUpOrDown()
    {
        if (Mathf.Round(lastY * 100f) / 100.0f == Mathf.Round(gameObject.transform.position.y * 100f) / 100.0f)
        {
            isStill = true;
        }
        else
        {
            isStill = false;
        }
            if (Mathf.Round(lastY * 100f) / 100.0f < Mathf.Round(gameObject.transform.position.y * 100f) /100.0f)
        {
            //Debug.Log("Y position is increasing");
            animator.SetBool("isFalling", false);
        }
        else
        {
            if (!isGrounded)
            {
                animator.SetBool("isFalling", true);
                animator.SetBool("isJumping", false);
            }
            else
            {
                animator.SetBool("isFalling", false);
            }
        }
        lastY = gameObject.transform.position.y;
    }
    void jumping()
    {
        if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W))
        {
            if (isGrounded && jumpAmount == 0 && isStill)
            {
                jump.Play();
                jumpAmount++;
                animator.SetBool("isJumping", true);
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            }

        }
    }
    void moving()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetKey("d") || Input.GetKey("a"))
        {
            if (isGrounded == true)
            {
                animator.SetBool("isRunning", true);
            }
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
    void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            jumpAmount = 0;
            isGrounded = true;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGrounded = true;
        }
    }
    void OnCollisionExit2D(UnityEngine.Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGrounded = false;
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, 10f);
    }
}
