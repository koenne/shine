using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class blackFireScript : MonoBehaviour
{
    public GameObject target;
    public redWitchScript redWitchScript;
    public Animator animator;
    public Collider2D col;

    private float speed = 4f;
    private float rotateSpeed = 500f;

    public Rigidbody2D rb;

    public AudioSource redHitSound;
    private bool isHit = false;
    // Update is called once per frame
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("RedWitch");
        redWitchScript = FindObjectOfType<redWitchScript>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (isHit)
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
        if (collision.gameObject.CompareTag("Player"))
        {
            isHit = true;
            col.enabled = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "redwitch")
        {
            animator.SetBool("isHit", true);
            rb.velocity = new Vector2(0, 0);
            rb.angularVelocity = 0;
            isHit = false;
            AudioSource.PlayClipAtPoint(redHitSound.clip, this.gameObject.transform.position);
            Object.Destroy(this.gameObject, 1f);
        }
    }
}
