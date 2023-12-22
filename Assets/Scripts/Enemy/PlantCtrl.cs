using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantCtrl : MonoBehaviour
{
    public CharacterAnimatorCtrl characterAnimatorCtrl;
    public LayerMask playerMask;

    public float distance;
    public float timeShoot;
    public float currentTimeShoot;

    private void Update()
    {
        CheckPlayer();
        PlantAttack();

        currentTimeShoot-= Time.deltaTime;
    }

    private void PlantAttack()
    {
        if (currentTimeShoot > 0)
        {
            characterAnimatorCtrl.animator.SetBool("Attack", true);
        }
        else
        {
            characterAnimatorCtrl.animator.SetBool("Attack", false);
        }
    }

    private void CheckPlayer()
    {
        if(Physics2D.Raycast(transform.position, -transform.right, distance, playerMask))
        {
            currentTimeShoot = timeShoot;
        }
    }
}
