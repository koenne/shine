using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class groundCheckMove : MonoBehaviour
{
    public void changeGravity(bool reverse)
    {
        if (reverse) 
        {
            this.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.05f);
        }
        else
        {
            this.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 0.05f);
        }
    }
}
