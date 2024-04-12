using UnityEngine;

public class checkpointScript : MonoBehaviour
{
    public Vector3 checkPointposition;
    private playerCheckpointScript playerCheckpointScript;
    private areaPlayerScript areaPlayerScript;
    public AudioSource checkPointSound;
    private bool catAnimate = false;
    public SpriteRenderer cat;
    private float opacity = 0;
    private bool didOnce = false;
    // Start is called before the first frame update
    void Start()
    {
        playerCheckpointScript = FindObjectOfType<playerCheckpointScript>();
        areaPlayerScript = FindObjectOfType<areaPlayerScript>();
        cat.color = new Color(1f, 1f, 1f, 0f);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "New Player")
        {
            checkPointposition = this.transform.position;
            playerCheckpointScript.saveCheckPoint(checkPointposition, areaPlayerScript.upOrDown, areaPlayerScript.leftOrRight);
            checkPointSound.Play();
            catAnimate = true;
        }
    }
    private void FixedUpdate()
    {
        if (catAnimate)
        {
            if(opacity < 2f && !didOnce)
            {
                opacity += 0.025f;
            }
            else
            {
                didOnce = true;
                opacity -= 0.025f;
                if(opacity < 0)
                {
                    catAnimate = false;
                    didOnce = false;
                    opacity = 0;
                }
            }
            cat.color = new Color(1f, 1f, 1f, opacity);
        }
    }
}
