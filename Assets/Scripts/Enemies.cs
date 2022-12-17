using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
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
    //! Agar Elang bergerak vertikal atas bawah (terbang di udara)
    void Update()
    {
        transform.position = startPos + transform.up * Mathf.Sin(Time.time + freq + offset) * magnitude;
    }
}
