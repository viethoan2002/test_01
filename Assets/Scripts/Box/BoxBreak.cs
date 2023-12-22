using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBreak : MonoBehaviour
{
    public ParticleSystem particle;
    public SpriteRenderer spriteRenderer;

    public bool animating;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!animating && collision.transform.CompareTag("Player"))
        {
            if (collision.GetComponent<PlayerStats>().isSuper)
            {
                spriteRenderer.enabled = false;
                particle.Play();
                transform.gameObject.layer = LayerMask.NameToLayer("Stun");
                StartCoroutine(DesObj());
            }
            else
                StartCoroutine(Animate());
        }
    }

    IEnumerator DesObj()
    {
        yield return new WaitForSeconds(0.6f);
        Destroy(gameObject);
    }

    IEnumerator Animate()
    {
        animating = true;

        Vector3 restingPos = transform.position;
        Vector3 animatedPos = restingPos + Vector3.up * 0.2f;

        yield return Move(restingPos, animatedPos);
        yield return Move(animatedPos, restingPos);

        animating = false;
    }

    IEnumerator Move(Vector3 from, Vector3 to)
    {
        float elapsed = 0f;
        float duration = 0.125f;

        while (elapsed < duration)
        {
            float t = elapsed / duration;

            transform.position = Vector3.Lerp(from, to, t);
            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.position = to;
    }
}
