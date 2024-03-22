using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCamera : MonoBehaviour
{
    public bool goLeft;
    public bool goLeftLeft;
    public bool goLeftRight;

    public bool goRight;
    public bool goRightLeft;
    public bool goRightRight;

    public bool goUp;
    public bool goUpUp;
    public bool goUpDown;

    public bool goDown;
    public bool goDownUp;
    public bool goDownDown;

    public Vector3 cameraPosition;
    private int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        cameraPosition = Camera.main.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (goLeft)
        {
            if (goLeftLeft && count == 0 && !goLeftRight)
            {
                count++;
                changePosition("left");
            }
        }
        if (goRight)
        {
            if (goRightRight && count == 0 && !goRightLeft)
            {
                count++;
                changePosition("right");
            }
        }
        if (goUp)
        {
            if(goUpUp && count == 0 && !goUpDown)
            {
                count++;
                changePosition("up");
            }
        }
        if (goDown)
        {
            if(goDownDown && count == 0 && !goDownUp)
            {
                count++;
                changePosition("down");
            }
        }
        if (!goDown && !goUp && !goRight && !goLeft)
        {
            count = 0;
        }
    }
    public void changePosition(string whatDirection)
    {
        cameraPosition = Camera.main.transform.position;
        switch (whatDirection)
        {
            case "left":
                transform.position = new Vector3(cameraPosition.x - 16, cameraPosition.y, cameraPosition.z);
                break;
            case "right":
                transform.position = new Vector3(cameraPosition.x + 16, cameraPosition.y, cameraPosition.z);
                break;
            case "up":
                transform.position = new Vector3(cameraPosition.x, cameraPosition.y + 9, cameraPosition.z);
                break;
            case "down":
                transform.position = new Vector3(cameraPosition.x, cameraPosition.y - 9, cameraPosition.z);
                break;
        }
        Reset();
    }
    public void Reset()
    {
        goUp = false;
        goDown = false;
        goRight = false;
        goLeft = false;
    }
}
