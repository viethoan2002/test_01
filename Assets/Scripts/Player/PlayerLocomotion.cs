using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerLocomotion : MonoBehaviour
{
    public Rigidbody2D rb;
    public PlayerComponent player;

    public float speed;
    public float jumpForce;

    public bool canMove;
    public bool isGround;
    public bool canDBJump;
    public bool isFlip;

    public Transform groundChecck;
    public Vector2 rectangle;

    public LayerMask groundMask;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(!canMove)
            return;

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
            player.playerAnimatorCtrl.PlayerTargetAnimation("Jump");
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            canDBJump = true;
        }
        //else if(InputHandle.Instance.Jump && canDBJump)
        //{
        //    player.playerAnimatorCtrl.PlayerTargetAnimation("DB_Jump");
        //    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        //    canDBJump = false;
        //}
    }

    private void HandleLocomotion()
    {
        if (InputHandle.Instance.horizontal > 0)
        {
            transform.rotation=Quaternion.Euler(0,0,0);
            isFlip = false;
        }else if(InputHandle.Instance.horizontal < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            isFlip = true;
        }

        Vector2 velocity = new Vector2(InputHandle.Instance.horizontal * speed, rb.velocity.y);
        rb.velocity = velocity;

        player.playerAnimatorCtrl.UpdateValueAnimation(isGround);
    }

    private void LateUpdate()
    {
        InputHandle.Instance.Jump = false;
    }

    public void Up()
    {
        player.playerAnimatorCtrl.PlayerTargetAnimation("Jump");
        rb.velocity = new Vector2(rb.velocity.x, jumpForce * 0.75f);

    }
}
