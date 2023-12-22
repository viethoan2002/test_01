using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushRoomLocomotion : MonoBehaviour
{
    private Rigidbody2D rb;
    public CharacterAnimatorCtrl enemyAnimator;
    public CheckPosition checkPosition;

    public bool isGround;
    public bool isFlip;
    public float speed;
    public float timeWait;

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
        isGround = checkPosition.Checked();

        if (isGround)
        {
            rb.velocity = speed * -transform.right;
        }
        else if(!isFlip)
        {
            rb.velocity=Vector2.zero;
            isFlip = true;
            enemyAnimator.PlayerTargetAnimation("Idle");;
           
            StartCoroutine(Flip());
        }
    }

    IEnumerator Flip()
    {
        yield return new WaitForSeconds(timeWait);
        isFlip = false;
        transform.Rotate(0, 180, 0);
        enemyAnimator.PlayerTargetAnimation("Run");
    }
}
