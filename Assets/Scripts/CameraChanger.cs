using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChanger : MonoBehaviour
{
    [SerializeField]
    private GameObject cameraObject;
    private float originalSize = 4.5f;
    public float newSize;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            cameraObject.GetComponent<moveCamera>().size = newSize;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            cameraObject.GetComponent<moveCamera>().size = originalSize;
        }
    }
}
