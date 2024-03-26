using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class areaPlayerScript : MonoBehaviour
{
    int[,] location = { { 0 }, { 0 } };
    private playerCameraScript playerCameraScript;
    // Start is called before the first frame update
    void Start()
    {
        playerCameraScript = FindObjectOfType<playerCameraScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void locationChange(string direction)
    {
        switch (direction)
        {
            case "Up":
                break;
            case "Down":
                break;
            case "Right":
                break;
            case "Left":
                break;
        }
    }
}
