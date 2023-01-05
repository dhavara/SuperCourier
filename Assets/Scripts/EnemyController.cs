using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public enum MoveDirection
    {
        Left,
        Right,
    }

    public Transform TransformPointA;
    public Transform TransformPointB;
    public float moveSpeed;
    private float currDirection;
    private MoveDirection moveDirection;
    private Rigidbody2D rb;
    
    public float length = 1;

    private Vector3 defaultPosition;



    // Start is called before the first frame update
    void Start()
    {
        defaultPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();

        Vector3 currPosition = transform.position;
        currPosition.x = transform.position.x;
        currPosition.y = transform.position.y + 0.75f;
    }

    void Update()
    { 
        switch (moveDirection)
        {
            case MoveDirection.Left:
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                currDirection = (TransformPointA.position - transform.position).normalized.x;
                length = Mathf.Abs(transform.position.x - TransformPointA.position.x);
                
                if (length < 0.1)
                {
                    moveDirection = MoveDirection.Right;
                }
                break;
            case MoveDirection.Right:
                transform.localRotation = Quaternion.Euler(0, 180, 0);
                currDirection = (TransformPointB.position - transform.position).normalized.x;
                length = Mathf.Abs(transform.position.x - TransformPointB.position.x);
                
                if (length < 0.1)
                {
                    moveDirection = MoveDirection.Left;
                }
                break;
        }
        Move(currDirection);
    }

    public void Move(float direction)
    {
        Vector3 velocity = rb.velocity;
        velocity.x = direction * moveSpeed;
        rb.velocity = velocity;
    }
}


