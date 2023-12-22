using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridDamage : MonoBehaviour
{
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.GetComponent<PlayerStats>().OnDead();
        }
    }
}
