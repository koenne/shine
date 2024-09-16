using TMPro;
using UnityEngine;

public class playerSpikes : MonoBehaviour
{
    private float timeRemaining = 0.5f;
    private bool isDead = false;
    private playerCheckpointScript playerCheckpointScript;
    private NewPlayerMovement NewPlayerMovement;
    private Rigidbody2D rb;
    public AudioSource deathSound;
    public Animator animator;
    public TextMeshProUGUI text;
    public int deathcount = 1;
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
            rb.simulated = false;
        }
        if(timeRemaining < 0 && isDead)
        {
            rb.simulated = true;
            playerCheckpointScript.teleport();
            timeRemaining = 0.5f;
            isDead = false;
            NewPlayerMovement.died(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spikes"))
        {
            animator.SetBool("isDead", true);
            isDead = true;
            NewPlayerMovement.died(false);
            deathSound.Play();
            deathcount++;
            text.text = "Deaths: " + deathcount;
        }
    }
    public void enemyHit()
    {
        animator.SetBool("isDead", true);
        isDead = true;
        NewPlayerMovement.died(false);
        deathSound.Play();
        deathcount++;
        text.text = "Deaths: " + deathcount;
    }
}
