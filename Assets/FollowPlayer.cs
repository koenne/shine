using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Vector3 myPos;
    public Transform myPlay;

    void Update()
    {
        transform.position = myPlay.position + new Vector3(myPos.x, myPos.y + 1.5f, -5);
    }
}
