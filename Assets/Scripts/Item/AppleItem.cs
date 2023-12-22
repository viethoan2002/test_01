using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleItem : MonoBehaviour
{
    Animator animator;
    Collider2D col;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            animator.CrossFade("Collected", 0.1f);
            col.enabled = false;
            GameManager.Instance.AddApple(1);
        }
    }

    public void DesObj()
    {
        Destroy(gameObject);
    }
}
