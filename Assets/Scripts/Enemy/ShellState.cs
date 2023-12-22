using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellState : State
{

    public override void UpdateSate(EnemyStateManager enemyStateManager)
    {
        enemyStateManager.isGround = enemyStateManager.checkPosition.Checked();

        if (enemyStateManager.isGround)
        {
            enemyStateManager.rb.velocity = enemyStateManager.speed * -transform.right;
        }
        else if (!enemyStateManager.isFlip)
        {
            enemyStateManager.rb.velocity = Vector2.zero;
            enemyStateManager.isFlip = true;
            enemyStateManager.enemyAnimator.PlayerTargetAnimation("Idle");
            Debug.Log("flip");

            StartCoroutine(Flip(enemyStateManager));
        }
    }

    IEnumerator Flip(EnemyStateManager enemyStateManager)
    {
        yield return new WaitForSeconds(enemyStateManager.timeWait);
        enemyStateManager.isFlip = false;
        enemyStateManager.transform.parent.Rotate(0, 180, 0);
        if(enemyStateManager.snail.currentState==this)
            enemyStateManager.enemyAnimator.PlayerTargetAnimation("Run");
        else
            enemyStateManager.enemyAnimator.PlayerTargetAnimation("Shell_Idle");
    }
}
