using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
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

    private float value1;
    private float value2;

    private areaPlayerScript areaPlayerScript;

    // Start is called before the first frame update
    void Start()
    {
        cameraPosition = Camera.main.transform.position;
        areaPlayerScript = FindObjectOfType<areaPlayerScript>();
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
                areaPlayerScript.locationChange("Left");
                break;
            case "right":
                transform.position = new Vector3(cameraPosition.x + 16, cameraPosition.y, cameraPosition.z);
                areaPlayerScript.locationChange("Right");
                break;
            case "up":
                transform.position = new Vector3(cameraPosition.x, cameraPosition.y + 9, cameraPosition.z);
                areaPlayerScript.locationChange("Up");
                break;
            case "down":
                transform.position = new Vector3(cameraPosition.x, cameraPosition.y - 9, cameraPosition.z);
                areaPlayerScript.locationChange("Down");
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
    public void resetAndMove(float upDown, float leftRight)
    {
        transform.position = new Vector3(0f, 0.5f, cameraPosition.z);
        value1 = 9f * upDown + 0.5f;
        value2 = 16f * leftRight;
        transform.position = new Vector3(value2, value1, cameraPosition.z);
    } 
}
