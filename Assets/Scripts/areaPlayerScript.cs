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
        //startTeleport();

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
    public void startingAreaTeleport()
    {
        upOrDown = 0;
        leftOrRight = 0;
        moveCamera.resetAndMove(upOrDown, leftOrRight);
        rb.position = new Vector2(0,0);
    }
    public void boss1AreaTeleport()
    {
        upOrDown = -3;
        leftOrRight = 2;
        moveCamera.resetAndMove(upOrDown, leftOrRight);
        rb.position = new Vector3(26.9500008f, -28.6299992f, -1);
    }
    public void boss2AreaTeleport()
    {
        upOrDown = 2;
        leftOrRight = 3;
        moveCamera.resetAndMove(upOrDown, leftOrRight);
        rb.position = cameraPos.position;
    }
}
