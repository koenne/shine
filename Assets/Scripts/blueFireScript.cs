using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class blueFireScript : MonoBehaviour
{
    public AudioSource blueFireSound;   
    public AudioSource redHitSound;
    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position += transform.right * Time.deltaTime * 5;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            AudioSource.PlayClipAtPoint(redHitSound.clip, this.gameObject.transform.position);
            Object.Destroy(this.gameObject);
        }

    }
}
