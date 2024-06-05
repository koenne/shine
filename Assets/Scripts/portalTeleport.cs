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
    // Start is called before the first frame update
    void Start()
    {
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
        if (isFlipped)
        {
            rb.position = new Vector2(otherPortal.transform.position.x + 1f, otherPortal.transform.position.y);
        }
        else
        {
            rb.position = new Vector2(otherPortal.transform.position.x - 1f, otherPortal.transform.position.y);
        }
        moveCamera.resetAndMove(upOrDown, leftOrRight);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            teleportSound.Play();
            teleport();
        }
    }
}
