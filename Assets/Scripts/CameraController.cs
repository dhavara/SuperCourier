using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector3 pos = transform.position;
            pos.x = player.transform.position.x + offset.x;
            pos.y = player.transform.position.y + offset.y;
            transform.position = pos;
        }
    }
}
