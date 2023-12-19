using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorCtrl : MonoBehaviour
{
    private Animator animator;
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

    public void UpdateValueAnimation()
    {
        
        animator.SetFloat("HORIZONTAL", Mathf.Abs(InputHandle.Instance.horizontal));
        animator.SetFloat("VERTICAL", InputHandle.Instance.vertical);

        if (InputHandle.Instance.horizontal > 0)
        {
            spriteRenderer.flipX = false;
        }else if (InputHandle.Instance.horizontal < 0)
        {
            spriteRenderer.flipX = true;
        }
    }
}
