using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class blueWitchScript : MonoBehaviour
{
    public GameObject magicBall;
    public GameObject blueWitch;
    public float shootTimer = 0.15f;
    public Vector3 dir;
    public int amount1 = 0;
    public int amount2 = 0;
    public int amount3 = 0;
    public GameObject bullet;
    public bossMusicScript bossMusic;
    // Update is called once per frame
    void Update()
    {
        if (bossMusic.starting)
        {
            shootTimer -= Time.deltaTime;
            if (shootTimer < 0)
            {
                shootTimer = 0.15f;
                bullet = (GameObject)GameObject.Instantiate(magicBall, transform.position + new Vector3(0, 0, Random.Range(-1, 1)), transform.rotation);
                transform.RotateAround(blueWitch.transform.localPosition, Vector3.back, Time.deltaTime * 25000);
            }
        }
    }
}
