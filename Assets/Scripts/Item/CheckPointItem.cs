using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointItem : MonoBehaviour
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
            collision.transform.GetComponent<PlayerStats>().checkPoint = this.transform.position;
            animator.CrossFade("CheckPoint_Out", 0.1f);
            col.enabled = false;
        }
    }
}
