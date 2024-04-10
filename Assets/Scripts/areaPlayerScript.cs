using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class areaPlayerScript : MonoBehaviour
{
    public float upOrDown = 0;
    public float leftOrRight = 0;
    public float startArearight;
    public float startAreaup;
    public bool go=false;
    private Rigidbody2D rb;
    public Transform cameraPos;

    private playerCameraScript playerCameraScript;
    private moveCamera moveCamera;
    // Start is called before the first frame update
    void Start()
    {
        playerCameraScript = FindObjectOfType<playerCameraScript>();
        moveCamera = FindObjectOfType<moveCamera>();
        rb = GetComponent<Rigidbody2D>();
        startTeleport();

    }

    public void locationChange(string direction)
    {
        switch (direction)
        {
            case "Up":
                upOrDown++;
                break;
            case "Down":
                upOrDown--;
                break;
            case "Right":
                leftOrRight++;
                break;
            case "Left":
                leftOrRight--;
                break;
        }
    }
    public void resetAndMove(float up, float right)
    {
        upOrDown = up;
        leftOrRight = up;
        moveCamera.resetAndMove(up, right);
    }
    public void newAreaCode(float up, float right)
    {
        upOrDown = up;
        leftOrRight = right;
    }
    private void startTeleport()
    {
        upOrDown = startAreaup;
        leftOrRight = startArearight;
        moveCamera.resetAndMove(startAreaup, startArearight);
        rb.position = cameraPos.position;
    }

}
