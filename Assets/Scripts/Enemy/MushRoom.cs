using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushRoom : MonoBehaviour
{
    public ParticleSystem particle;
    public GameObject Model;

    public bool canDamage;
    public bool isDead;

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
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.GetComponent<PlayerLocomotion>().Up();
            OnDead();
        }
    }

    public void OnDead()
    {
        GameManager.Instance.AddScore(20);

        isDead = true;
        canDamage = false;
        transform.gameObject.layer = LayerMask.NameToLayer("Stun");

        particle.Play();
        if (Model != null)
        {
            Model.SetActive(false);
            StartCoroutine(DesObj());
        }
    }

    IEnumerator DesObj()
    {
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }
}
