using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class blueWitchScript : MonoBehaviour
{
    public GameObject blueMagicBall;
    public GameObject greenMagicBall;
    public GameObject blueWitch;
    private float shootTimer = 1f;
    private float shootTimer2 = 1.5f;
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
            shootTimer2 -= Time.deltaTime;
            if (shootTimer < 0)
            {
                shootTimer = 0.3f;
                bullet = (GameObject)GameObject.Instantiate(blueMagicBall, transform.position + new Vector3(0, 0, Random.Range(-2, 2)), transform.rotation);
                transform.RotateAround(blueWitch.transform.localPosition, Vector3.back, Time.deltaTime * 25000);
            }
            if (shootTimer2 < 0)
            {
                shootTimer2 = 0.3f;
                bullet = (GameObject)GameObject.Instantiate(greenMagicBall, transform.position + new Vector3(0, 0, Random.Range(-2, 2)), transform.rotation);
                transform.RotateAround(blueWitch.transform.localPosition, Vector3.back, Time.deltaTime * 30000);
            }
        }
    }
}
