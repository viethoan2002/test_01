using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : MonoBehaviour
{
    private Rigidbody2D rb;

    public bool isGround;
    public int isFlip = 1;
    public float speed;

    public Transform groundChecck;
    public Vector2 rectangle;

    public LayerMask groundMask;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(groundChecck.position, new Vector3(rectangle.x, rectangle.y, 1));
    }

    private void Update()
    {
        EnemyMove();
    }

    private void EnemyMove()
    {
        isGround = Physics2D.OverlapBox(groundChecck.position, new Vector2(rectangle.x, rectangle.y), groundMask);

        if (isGround)
        {
            rb.velocity = speed * -transform.right;
        }
        else
        {
            Flip();
        }
    }

    private void Flip()
    {
        transform.Rotate(0, 180, 0);
    }
}
