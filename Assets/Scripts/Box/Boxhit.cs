using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Boxhit : MonoBehaviour
{
    public Transform posSpawn;
    public Sprite emptyBlock;
    public int maxHits;
    public GameObject Item;

    public bool animating;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!animating && maxHits > 0 && collision.transform.CompareTag("Player"))
        {
            Hit();
        }
    }

    private void Hit()
    {
        SpriteRenderer spriteRenderer=transform.GetComponent<SpriteRenderer>(); ;
        spriteRenderer.enabled = true;

        maxHits--;
        if(maxHits == 0)
        {
            spriteRenderer.sprite=emptyBlock;
        }

        if(Item != null)
        {
            Instantiate(Item, posSpawn.position, Quaternion.identity);
        }

        StartCoroutine(Animate());
    }

    IEnumerator Animate()
    {
        animating = true;

        Vector3 restingPos = transform.position;
        Vector3 animatedPos = restingPos + Vector3.up * 0.2f;

        yield return Move(restingPos, animatedPos);
        yield return Move(animatedPos, restingPos);

        animating=false;
    }

    IEnumerator Move(Vector3 from,Vector3 to)
    {
        float elapsed = 0f;
        float duration = 0.125f;

        while(elapsed < duration)
        {
            float t=elapsed/duration;

            transform.position=Vector3.Lerp(from, to, t);
            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.position = to;
    }
}
