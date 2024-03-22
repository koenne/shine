using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCameraScript : MonoBehaviour
{
    private moveCamera moveCamera; 
    // Start is called before the first frame update
    void Start()
    {
        moveCamera = FindObjectOfType<moveCamera>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        switch (collision.gameObject.name)
        {
            case "rightSecondColliderRight":
                //moveCamera.changePosition("right");
                moveCamera.goRightRight = true;
                break;
            case "rightSecondColliderLeft":
                moveCamera.goRightLeft = true;
                break;

            case "leftSecondColliderLeft":
                //moveCamera.changePosition("left");
                moveCamera.goLeftLeft = true;
                break;
            case "leftSecondColliderRight":
                //moveCamera.changePosition("left");
                moveCamera.goLeftRight = true;
                break;

            case "upSecondColliderUp":
                //moveCamera.changePosition("left");
                moveCamera.goUpUp = true;
                break;
            case "upSecondColliderDown":
                //moveCamera.changePosition("left");
                moveCamera.goUpDown = true;
                break;

            case "downSecondColliderDown":
                //moveCamera.changePosition("left");
                moveCamera.goDownDown = true;
                break;
            case "downSecondColliderUp":
                //moveCamera.changePosition("left");
                moveCamera.goDownUp = true;
                break;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.gameObject.name)
        {
            case "rightCollider":
                //moveCamera.changePosition("right");
                moveCamera.goRight = true;
                break;
            case "leftCollider":
                //moveCamera.changePosition("left");
                moveCamera.goLeft = true;
                break;
            case "upCollider":
                //moveCamera.changePosition("up");
                moveCamera.goUp = true;
                break;
            case "downCollider":
                //moveCamera.changePosition("down");
                moveCamera.goDown = true;
                break;
        }
        switch (collision.gameObject.name)
        {
            case "rightSecondColliderRight":
                //moveCamera.changePosition("right");
                moveCamera.goRightRight = false;
                break;
            case "rightSecondColliderLeft":
                moveCamera.goRightLeft = false;
                break;

            case "leftSecondColliderLeft":
                //moveCamera.changePosition("left");
                moveCamera.goLeftLeft = false;
                break;
            case "leftSecondColliderRight":
                //moveCamera.changePosition("left");
                moveCamera.goLeftRight = false;
                break;

            case "upSecondColliderUp":
                //moveCamera.changePosition("left");
                moveCamera.goUpUp = false;
                break;
            case "upSecondColliderDown":
                //moveCamera.changePosition("left");
                moveCamera.goUpDown = false;
                break;

            case "downSecondColliderDown":
                //moveCamera.changePosition("left");
                moveCamera.goDownDown = false;
                break;
            case "downSecondColliderUp":
                //moveCamera.changePosition("left");
                moveCamera.goDownUp = false;
                break;

        }
    }
}
