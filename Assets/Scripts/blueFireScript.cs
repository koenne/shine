using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blueFireScript : MonoBehaviour
{
    public AudioSource blueFireSound;   
    public AudioSource redHitSound;
    private void Start()
    {
        blueFireSound.Play();
    }
    // Update is called once per frame
    void Update()
    {
        this.transform.position += transform.right * Time.deltaTime * 5;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            redHitSound.Play();
            Object.Destroy(this.gameObject);

        }

    }
}
