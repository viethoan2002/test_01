using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerLocomotion : MonoBehaviour
{
    public Rigidbody2D rb;
    public PlayerAnimatorCtrl playerAnimatorCtrl;

    public float speed;
    public float jumpForce;
    public bool isGround;

    public Transform groundChecck;
    public Vector2 rectangle;

    public LayerMask groundMask;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HandleLocomotion();
        HandleJump();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(groundChecck.position, new Vector3(rectangle.x, rectangle.y, 1));
    }

    private void HandleJump()
    {
        isGround = Physics2D.OverlapBox(groundChecck.position, new Vector2(rectangle.x, rectangle.y), groundMask);
        
        if (InputHandle.Instance.Jump && isGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void HandleLocomotion()
    {
        Vector2 velocity = new Vector2(InputHandle.Instance.horizontal * speed, rb.velocity.y);
        rb.velocity = velocity;

        playerAnimatorCtrl.UpdateValueAnimation();
    }

    private void LateUpdate()
    {
        InputHandle.Instance.Jump = false;
    }
}
