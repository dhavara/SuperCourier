using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 startPos;
    [SerializeField] float freq = 5f;
    [SerializeField] float magnitude = 5f;
    [SerializeField] float offset = 0f;

    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    //! Agar Tikus bergerak horizontal maju - mundur (kiri - kanan)
    void Update()
    {
        transform.position = startPos + transform.right * Mathf.Sin(Time.time + freq + offset) * magnitude;
    }
}

