using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private float horizontal = 1f;
    private float speed = 1f;
    private Rigidbody2D rb;
    private playerSpikes playerSpikes;
    private float count = 0f;
    public Animator animator;
    private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
        playerSpikes = FindObjectOfType<playerSpikes>();
        Flip();
        animator.gameObject.GetComponent<Animator>().enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Spikes"))
        {
            if(count > 0.15f)
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
        if(count > 0.15f)
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
            count += Time.deltaTime;
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
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
}
