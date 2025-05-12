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
    public bool isUp;
    public bool isDown;
    public bool isLeft;
    public bool isRight;
    public portalTeleport portal;
    private float velocity;
    private CharacterController2D characterController;
    public bool ignoreSpeed;
    public float customUp = 0.25f;
    public bool hasTeleported = false;
    // Start is called before the first frame update
    void Start()
    {
        characterController = FindObjectOfType<CharacterController2D>();
        moveCamera = FindObjectOfType<moveCamera>();
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
        if(!isUp && !isDown && !isLeft && !isRight)
        {
            rb.position = new Vector2(otherPortal.transform.position.x, otherPortal.transform.position.y);
        }
        if(isUp)
        {
            rb.position = new Vector2(otherPortal.transform.position.x, otherPortal.transform.position.y - 0.25f);
            if (otherPortal.GetComponent<portalTeleport>().isRight && !ignoreSpeed)
            {
                velocity = -rb.velocity.y;
                characterController.setVelocityX(velocity);
                rb.velocity = new Vector2(rb.velocity.x, 0);
            }
            if (otherPortal.GetComponent<portalTeleport>().isLeft && !ignoreSpeed)
            {
                velocity = rb.velocity.y;
                characterController.setVelocityX(velocity);
                rb.velocity = new Vector2(rb.velocity.x, 0);
            }
        }
        if (isDown)
        {
            rb.position = new Vector2(otherPortal.transform.position.x, otherPortal.transform.position.y + 1f);
            if (otherPortal.GetComponent<portalTeleport>().isRight && !ignoreSpeed)
            {
                velocity = rb.velocity.x;
                rb.velocity = new Vector2(rb.velocity.x, 0);
                characterController.setVelocityY(velocity);
            }
            if (otherPortal.GetComponent<portalTeleport>().isLeft && !ignoreSpeed)
            {
                velocity = rb.velocity.x;
                rb.velocity = new Vector2(rb.velocity.x, 0);
                characterController.setVelocityY(velocity);
            }
        }
        if (isLeft)
        {
            rb.position = new Vector2(otherPortal.transform.position.x + 0.5f, otherPortal.transform.position.y);
        }
        if (isRight)
        {
            rb.position = new Vector2(otherPortal.transform.position.x - 0.5f, otherPortal.transform.position.y);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !portal.hasTeleported)
        {
            teleportSound.Play();
            teleport();
            hasTeleported = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            portal.hasTeleported = false;
        }
    }
}
