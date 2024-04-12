using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private float horizontal = 1f;
    private float speed = 1.5f;
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

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Spikes"))
        {
            if(count > 0.5)
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
        if(count > 0.5)
        {
            speed *= -1;
            Flip();
            count = 0;
        }

    }
}
