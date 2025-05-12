using UnityEngine;

public class areaPlayerScript : MonoBehaviour
{
    public bool go=false;
    private Rigidbody2D rb;
    public Transform cameraPos;
    public bool startingTeleportYes;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (startingTeleportYes)
        {
            startTeleport();
        }
    }
    private void startTeleport()
    {
        rb.position = cameraPos.position;
    }
    public void startingAreaTeleport()
    {
        rb.position = new Vector2(0,0);
    }
    public void boss1AreaTeleport()
    {
        rb.position = new Vector3(27, -29f, -1);
    }
    public void boss2AreaTeleport()
    {
        rb.position = new Vector3(47, 16, -1);
    }
}
