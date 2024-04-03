using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSpikes : MonoBehaviour
{
    private float timeRemaining = 0.5f;
    private bool isDead = false;
    private playerCheckpointScript playerCheckpointScript;
    private NewPlayerMovement NewPlayerMovement;
    private Rigidbody2D rb;
    public AudioSource deathSound;
    // Start is called before the first frame update
    void Start()
    {
        playerCheckpointScript = FindObjectOfType<playerCheckpointScript>();
        NewPlayerMovement = FindObjectOfType<NewPlayerMovement>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0 && isDead)
        {
            timeRemaining -= Time.deltaTime;
            Debug.Log(timeRemaining);
            rb.isKinematic = true;
        }
        if(timeRemaining < 0 && isDead)
        {
            playerCheckpointScript.teleport();
            timeRemaining = 1.5f;
            isDead = false;
            NewPlayerMovement.died(true);
            rb.isKinematic = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spikes"))
        {
            isDead = true;
            NewPlayerMovement.died(false);
            deathSound.Play();
        }
    }
}
