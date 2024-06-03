using UnityEngine;

public class blueWitchScript : MonoBehaviour
{
    public GameObject blueMagicBall;
    public GameObject blueWitch;
    public float shootTimer = 2f;
    public GameObject bullet;
    public bossMusicScript bossMusic;
    private int timerInt = 0;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (bossMusic.starting)
        {
            FireFunction();
        }
    }
    public void FireFunction()
    {
            timerInt++;
            if (timerInt % 4 == 0)
            {
                bullet = GameObject.Instantiate(blueMagicBall, transform.position + new Vector3(0, 0, 0), transform.rotation);
                transform.RotateAround(blueWitch.transform.localPosition, -Vector3.back, 10);
            }
            else if(timerInt % 4 == 2)
            {
                bullet = GameObject.Instantiate(blueMagicBall, transform.position + new Vector3(0, 0, 0), new Quaternion(transform.rotation.x,transform.rotation.y,-transform.rotation.z,transform.rotation.w));
                transform.RotateAround(blueWitch.transform.localPosition, Vector3.forward, 10);
            }
    }
}
