using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    // Update is called once per frame
    //! Agar kamera bergerak mengikuti posisi karakter Fox dengan posisi offset yang spesifik
    void Update()
    {
        transform.position = new Vector3 (player.position.x + offset.x, player.position.y + offset.y, offset.z); 
    }
}
