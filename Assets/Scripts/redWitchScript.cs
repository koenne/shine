using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redWitchScript : MonoBehaviour
{
    public GameObject blueMagicBall;
    public GameObject redWitch;
    public GameObject wall;
    public float shootTimer = 1f;
    public Vector3 dir;
    private GameObject bullet;
    public bossMusicScript1 bossMusic;
    public int damage = 3;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (bossMusic.starting)
        {
            shootTimer -= Time.deltaTime;
            if (shootTimer < 0)
            {
                shootTimer = 1;
                bullet = (GameObject)GameObject.Instantiate(blueMagicBall, transform.position + new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1)), transform.rotation);
            }
        }
        if(damage == 0)
        {
            bossMusic.destroying();
            Destroy(wall);
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BlackFire"))
        {
            damage--;
        }
    }
}
