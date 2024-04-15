using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private float horizontal = 1f;
    private float speed = 1f;
    private Rigidbody2D rb;
    private playerSpikes playerSpikes;
    private float count = 0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerSpikes = FindObjectOfType<playerSpikes>();
        Flip();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Spikes"))
        {
            if(count > 0.2)
            {
            speed *= -1;
            Flip();
            }
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            playerSpikes.enemyHit();
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
        if(count > 0.2)
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
        }
    }
}
