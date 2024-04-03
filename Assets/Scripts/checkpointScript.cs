using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpointScript : MonoBehaviour
{
    public Vector3 checkPointposition;
    private playerCheckpointScript playerCheckpointScript;
    private areaPlayerScript areaPlayerScript;
    public AudioSource checkPointSound;
    // Start is called before the first frame update
    void Start()
    {
        playerCheckpointScript = FindObjectOfType<playerCheckpointScript>();
        areaPlayerScript = FindObjectOfType<areaPlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "New Player")
        {
            checkPointposition = this.transform.position;
            playerCheckpointScript.saveCheckPoint(checkPointposition, areaPlayerScript.upOrDown, areaPlayerScript.leftOrRight);
            checkPointSound.Play();
        }
    }
}
