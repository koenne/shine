using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redFireScript : MonoBehaviour
{

    private GameObject target;
    public Animator animator;

    public float speed = 5f;
    public float rotateSpeed = 200f;

    private Rigidbody2D rb;

    public AudioSource blueFireSound;
    public AudioSource redHitSound;
    public Collider2D col;
    private bool isHit = false;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player");
    }

    void FixedUpdate()
    {
        if (!isHit)
        {
        Vector2 direction = (Vector2)target.transform.position - rb.position;

        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.up).z;

        rb.angularVelocity = -rotateAmount * rotateSpeed;

        rb.velocity = transform.up * speed;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("isHit", true);
            isHit = true;
            rb.velocity = new Vector2(0,0);
            rb.angularVelocity = 0;
            col.enabled = false;
            AudioSource.PlayClipAtPoint(redHitSound.clip, this.gameObject.transform.position);
            Object.Destroy(this.gameObject,1f);
        }
    }
}
