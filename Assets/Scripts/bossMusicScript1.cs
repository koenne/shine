using Unity.VisualScripting;
using UnityEngine;

public class bossMusicScript1 : MonoBehaviour
{
    public bool starting = false;
    public AudioSource normaMusic; 
    public AudioSource bulletMusic;
    public GameObject wall;
    public bool normal = false;
    public bool boss = false;
    public float volumeUp = 0;
    public float volumeDown = 0;
    private bool dead = false;
    private bool entered = false;
    private float enteredTimer = 0;
    public redWitchScript redWitchScript;
    public GameObject blackFire;
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
        if (entered)
        {
            enteredTimer += Time.deltaTime;
            if(enteredTimer > 0.1f)
            {
                entered = false;
                enteredTimer = 0;
                wall.SetActive(true);
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(!dead)
            {
                starting = true;
                boss = true;
                normal = false;
                volumeUp = 0;
                volumeDown = 1;
                entered = true;
                spawnFire();
                resetHealth();
            }

        }
    }
    void spawnFire()
    {
        Instantiate(blackFire, new Vector2(32, 16), Quaternion.identity);
        Instantiate(blackFire, new Vector2(29.5f, 20), Quaternion.identity);
        Instantiate(blackFire, new Vector2(35.5f, 20), Quaternion.identity);
    }
    void resetHealth()
    {
        redWitchScript.damage = 3;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!dead)
            {
                starting = false;
                normal = true;
                boss = false;
                volumeUp = 0;
                volumeDown = 1;
                wall.SetActive(false);
                GameObject[] gos = GameObject.FindGameObjectsWithTag("BlackFire");
                foreach (GameObject go in gos)
                    Destroy(go);
            }
        }
    }
    public void destroying()
    {
        if (!dead)
        {
        starting = false;
        normal = true;
        boss = false;
        volumeUp = 0;
        volumeDown = 1;
        dead = true;
        }

    }
}
