using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class portalTeleport : MonoBehaviour
{
    private moveCamera moveCamera;
    public int upOrDown;
    public int leftOrRight;
    public Rigidbody2D rb;
    private GameObject player;
    public GameObject otherPortal;
    public bool isFlipped;
    public AudioSource teleportSound;
    public areaPlayerScript areaPlayer;
    public bool isUp;
    public bool isDown;
    public bool isLeft;
    public bool isRight;
    private Vector3 test;
    // Start is called before the first frame update
    void Start()
    {
        moveCamera = FindObjectOfType<moveCamera>();
        areaPlayer = FindObjectOfType<areaPlayerScript>();
        player = GameObject.FindGameObjectWithTag("Player");
        rb = player.gameObject.GetComponent<Rigidbody2D>();
        if (isFlipped)
        {
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
    public void teleport()
    {
        test = rb.velocity;
        if(isUp)
        {
            rb.position = new Vector2(otherPortal.transform.position.x, otherPortal.transform.position.y - 0.5f);
        }
        if (isDown)
        {
            rb.position = new Vector2(otherPortal.transform.position.x, otherPortal.transform.position.y + 0.5f);
        }
        if (isLeft)
        {
            rb.position = new Vector2(otherPortal.transform.position.x + 0.25f, otherPortal.transform.position.y);
        }
        if (isRight)
        {
            rb.position = new Vector2(otherPortal.transform.position.x - 0.25f, otherPortal.transform.position.y);
        }
        rb.velocity = test;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            teleportSound.Play();
            teleport();
            //areaPlayer.upOrDown = upOrDown;
            //areaPlayer.leftOrRight = leftOrRight;
        }
    }
}
