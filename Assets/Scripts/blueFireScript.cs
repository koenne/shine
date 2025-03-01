using UnityEngine;

public class blueFireScript : MonoBehaviour
{
    public AudioSource blueFireSound;   
    public AudioSource redHitSound;

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position += transform.right * Time.deltaTime * 4f;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(redHitSound.clip, this.gameObject.transform.position);
            Object.Destroy(this.gameObject);
        }

    }
}
