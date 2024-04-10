using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class blackFireScript : MonoBehaviour
{
    public GameObject target;
    public redWitchScript redWitchScript;

    public float speed = 4f;
    private float rotateSpeed = 500f;

    public Rigidbody2D rb;

    public AudioSource blueFireSound;
    public AudioSource redHitSound;
    private bool isHit = false;
    // Update is called once per frame
    private void Start()
    {
        target = GameObject.Find("redwitch");
        rb = target.GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
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
            //redHitSound.Play();
        }
        if (collision.gameObject.layer.Equals("RedWitch"))
        {
            AudioSource.PlayClipAtPoint(redHitSound.clip, this.gameObject.transform.position);
            Object.Destroy(this.gameObject, 1f);
        }
    }
}
