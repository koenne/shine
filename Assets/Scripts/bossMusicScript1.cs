using UnityEngine;

public class bossMusicScript1 : MonoBehaviour
{
    public bool starting = false;
    public AudioSource normaMusic; 
    public AudioSource bulletMusic;
    public bool normal = false;
    public bool boss = false;
    public float volumeUp = 0;
    public float volumeDown = 0;
    bool dead = false;
    private void FixedUpdate()
    {
        if(boss)
        {


            if (boss && volumeUp < 1)
            {
                volumeUp += 0.01f;
                volumeDown -= 0.01f;
                boss = true;
            }
            else
            {
                normal = false;
                boss = false;
            }
            bulletMusic.volume = volumeUp;
            normaMusic.volume = volumeDown;

        }
        if (normal)
        {
            if (normal && volumeUp < 1)
            {
                volumeUp += 0.01f;
                volumeDown -= 0.01f;
                normal = true;
            }
            else
            {
                normal = false;
                boss = false;
            }
            bulletMusic.volume = volumeDown;
            normaMusic.volume = volumeUp;
        }
        if(dead)
        {
            Object.Destroy(this.gameObject, 10f);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            starting = true;
            boss = true;
            normal = false;
            volumeUp = 0;
            volumeDown = 1;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            starting = false;
            normal = true;
            boss = false;
            volumeUp = 0;
            volumeDown = 1;
        }
    }
    public void destroying()
    {
        normal = true;
        boss = false;
        dead = true;
        volumeUp = 0;
        volumeDown = 1;
    }
}
