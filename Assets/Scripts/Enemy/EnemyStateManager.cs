using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    public Rigidbody2D rb;
    public CharacterAnimatorCtrl enemyAnimator;
    public CheckPosition checkPosition;

    public bool isGround;
    public bool isFlip;
    public float speed;
    public float timeWait;

    public Transform groundChecck;
    public Vector2 rectangle;

    public LayerMask groundMask;
    public Snail snail;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(groundChecck.position, new Vector3(rectangle.x, rectangle.y, 1));
    }
}
