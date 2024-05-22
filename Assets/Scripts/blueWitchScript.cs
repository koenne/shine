using UnityEngine;

public class blueWitchScript : MonoBehaviour
{
    public GameObject blueMagicBall;
    public GameObject blueWitch;
    public float shootTimer = 2f;
    public Vector3 dir;
    public int amount1 = 0;
    public int amount2 = 0;
    public int amount3 = 0;
    public GameObject bullet;
    public bossMusicScript bossMusic;
    public bool isSecond;
    private int timerInt = 0;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (bossMusic.starting)
        {
            //shootTimer += Time.deltaTime;
            //if(timerInt % 2 == 0)
            {
                FireFunction();
                //shootTimer = 0;
            }
        }
    }
    public void FireFunction()
    {
            timerInt++;
            if (isSecond && timerInt % 4 == 0)
            {
                bullet = GameObject.Instantiate(blueMagicBall, transform.position + new Vector3(0, 0, 0), transform.rotation);
                transform.RotateAround(blueWitch.transform.localPosition, -Vector3.back, 3f);
            }
            else if(timerInt % 4 == 2)
            {;
                bullet = GameObject.Instantiate(blueMagicBall, transform.position + new Vector3(0, 0, 0), new Quaternion(transform.rotation.x,transform.rotation.y,-transform.rotation.z,transform.rotation.w));
                transform.RotateAround(blueWitch.transform.localPosition, Vector3.back, -3f);
            }
    }
}
