using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;

    public float jumpSpeed;
    public float moveSpeed;

    // public GlobalVariable global;
    public Action<Collision2D> onCollisionEnter;

    public GameObject panelGameOver;

    public GameObject customer;

    public AudioSource audioMoney;
    public AudioSource audioJump;
    public AudioSource audioDead;
    public AudioSource bgSound;

    private bool faceRight = true;

    // Start is called before the first frame update

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {            
        Vector3 currPosition = transform.position;
        currPosition.x = transform.position.x;
        currPosition.y = transform.position.y + 0.75f;
        
        if (this.transform.position.y < -6)
        {
            panelGameOver.SetActive(true);
        }
    }

    public void Move(float direction) 
    {
        if (direction < 0)
        {
            if (faceRight == true)
            {
                faceRight = false;
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
        }
        else if (direction > 0)
        {
            if (faceRight == false)
            {
                faceRight = true;
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
        }
        Vector3 velocity = rb.velocity;
        velocity.x = direction * moveSpeed;
        rb.velocity = velocity;
    }

    public void Jump()
    {
        Vector3 velocity = rb.velocity;
        velocity.y = moveSpeed;
        rb.velocity = velocity;
        audioJump.Play();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            bgSound.Stop();
            panelGameOver.SetActive(true);
        }
        onCollisionEnter.Invoke(collision);
    }
}
