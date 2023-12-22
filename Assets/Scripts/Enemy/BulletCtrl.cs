using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    Rigidbody2D rb;
    public ParticleSystem particle;
    public Vector2 direction;
    public float speed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity=direction*speed;
    }

    public void SetDirection(Vector2 direction)
    {
        this.direction = direction;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            if (collision.transform.GetComponent<PlayerStats>().isSuper)
            {
                collision.transform.GetComponent<PlayerStats>().OnTini();
            }
            else
                collision.transform.GetComponent<PlayerStats>().OnDead();

            rb.velocity = Vector2.zero;
            particle.Play();
            transform.GetComponent<Collider2D>().enabled = false;
            transform.GetComponent<SpriteRenderer>().enabled = false;
            StartCoroutine(DesObj());
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            rb.velocity = Vector2.zero;
            particle.Play();
            transform.GetComponent<Collider2D>().enabled = false;
            transform.GetComponent<SpriteRenderer>().enabled = false;
            StartCoroutine(DesObj());
        }
    }

    IEnumerator DesObj()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
