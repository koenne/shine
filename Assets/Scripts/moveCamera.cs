using Unity.Mathematics;
using UnityEngine;

public class moveCamera : MonoBehaviour
{

    public Vector3 cameraPosition;
    private bool isPlayer = false;

    public GameObject player;

    private areaPlayerScript areaPlayerScript;
    void FixedUpdate()
    {
        if (!isPlayer)
        {
            check();
        }
    }
    // Start is called before the first frame update
    void Start() 
    {
        cameraPosition = Camera.main.transform.position;
        areaPlayerScript = FindObjectOfType<areaPlayerScript>();
    }
    public void changePosition(string whatDirection)
    {
        cameraPosition = Camera.main.transform.position;
        switch (whatDirection)
        {
            case "left":
                transform.position = new Vector3(cameraPosition.x - 16f, cameraPosition.y, cameraPosition.z);
                break;
            case "right":
                transform.position = new Vector3(cameraPosition.x + 16f, cameraPosition.y, cameraPosition.z);
                break;
            case "up":
                transform.position = new Vector3(cameraPosition.x, cameraPosition.y + 9f, cameraPosition.z);
                break;
            case "down":
                transform.position = new Vector3(cameraPosition.x, cameraPosition.y - 9f, cameraPosition.z);
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayer = false;
        }
    }
    void check()
    {
        if (this.transform.position.x - 8 > player.transform.position.x)
        {
            changePosition("left");
        }
        else if (this.transform.position.x + 8 < player.transform.position.x)
        {
            changePosition("right");
        }
        if (this.transform.position.y - 4.45f > math.round(player.transform.position.y))
        {   
            changePosition("down");
        }
        else if (this.transform.position.y + 4.55f < math.round(player.transform.position.y))
        {
            changePosition("up");
        }
    }
}
