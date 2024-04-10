using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redWitchScript : MonoBehaviour
{
    public GameObject blueMagicBall;
    public GameObject redWitch;
    public float shootTimer = 1f;
    public Vector3 dir;
    private GameObject bullet;
    public bossMusicScript bossMusic;
    // Update is called once per frame
    void Update()
    {
        if (bossMusic.starting)
        {
            shootTimer -= Time.deltaTime;
            if (shootTimer < 0)
            {
                shootTimer = 1f;
                bullet = (GameObject)GameObject.Instantiate(blueMagicBall, transform.position + new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1)), transform.rotation);
            }
        }
    }
}
