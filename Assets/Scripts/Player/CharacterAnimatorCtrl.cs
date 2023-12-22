using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimatorCtrl : MonoBehaviour
{
    public PlayerComponent player;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void PlayerTargetAnimation(string targetAnim)
    {
        animator.CrossFade(targetAnim, 0.1f);
    }

    public void UpdateValueAnimation(bool isGround)
    {
        if (player.locomotion.canMove)
        {
            animator.SetFloat("HORIZONTAL", Mathf.Abs(InputHandle.Instance.horizontal));
            animator.SetFloat("VERTICAL", InputHandle.Instance.vertical);
            animator.SetBool("isGround", isGround);
        }
        else
        {
            animator.SetFloat("HORIZONTAL", 0);
            animator.SetFloat("VERTICAL", 0);
            animator.SetBool("isGround", true);
        }
        
    }
}
