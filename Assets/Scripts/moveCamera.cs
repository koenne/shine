using Unity.Mathematics;
using UnityEngine;

public class moveCamera : MonoBehaviour
{
    public Vector3 cameraPosition;
    private bool isPlayer = false;

    public GameObject player;
    private Camera _camera;
    public float size;
    public float smoothSpeed = 5f;
    public float zoomSpeed;

    private Vector3 targetPosition;
    private float horizontalCheck;
    private float verticalCheck;

    void Start()
    {
        _camera = GetComponent<Camera>();
        horizontalCheck = (size / 0.28125f);
        verticalCheck = (size / 0.5f);
        targetPosition = transform.position;
    }

    void Update()
    {
        if (!isPlayer)
        {
            check();
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        _camera.orthographicSize = Mathf.Lerp(_camera.orthographicSize, size, zoomSpeed * Time.deltaTime);
    }

    public void changePosition(string whatDirection)
    {
        switch (whatDirection)
        {
            case "left":
                targetPosition = new Vector3(targetPosition.x - horizontalCheck, targetPosition.y, targetPosition.z);
                break;
            case "right":
                targetPosition = new Vector3(targetPosition.x + horizontalCheck, targetPosition.y, targetPosition.z);
                break;
            case "up":
                targetPosition = new Vector3(targetPosition.x, targetPosition.y + verticalCheck, targetPosition.z);
                break;
            case "down":
                targetPosition = new Vector3(targetPosition.x, targetPosition.y - verticalCheck, targetPosition.z);
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

    public void check()
    {
        float zoneWidth = size / 0.5625f;
        float zoneHeight = size;

        if (targetPosition.x - zoneWidth > player.transform.position.x)
        {
            changePosition("left");
        }
        else if (targetPosition.x + zoneWidth < player.transform.position.x)
        {
            changePosition("right");
        }

        float buffer = 0.25f; // Tweak to taste

        if (targetPosition.y - zoneHeight - buffer > player.transform.position.y)
        {
            changePosition("down");
        }
        else if (targetPosition.y + zoneHeight + buffer < player.transform.position.y)
        {
            changePosition("up");
        }
    }
}
