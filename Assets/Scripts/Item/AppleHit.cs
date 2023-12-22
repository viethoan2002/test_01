using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleHit : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(Animate());
    }

    IEnumerator Animate()
    {
        Vector3 restingPos = transform.position;
        Vector3 animatedPos = restingPos + Vector3.up * 0.5f;

        yield return Move(restingPos, animatedPos);
        yield return Move(animatedPos, restingPos);

        GameManager.Instance.AddApple(1);
        Destroy(gameObject);
    }

    IEnumerator Move(Vector3 from, Vector3 to)
    {
        float elapsed = 0f;
        float duration = 0.2f;

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
