using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class WithOutShellState : State
{
    public override void UpdateSate(EnemyStateManager enemyStateManager)
    {
        if (enemyStateManager.snail.isDead)
            return;

        enemyStateManager.isGround = enemyStateManager.checkPosition.Checked();

        if (enemyStateManager.isGround)
        {
            enemyStateManager.rb.velocity = enemyStateManager.speed * 7 * -transform.right;
        }
        else if (!enemyStateManager.isFlip)
        {
            enemyStateManager.rb.velocity = Vector2.zero;
            enemyStateManager.isFlip = true;
            enemyStateManager.enemyAnimator.PlayerTargetAnimation("Shell_Top_Hit");

            StartCoroutine(Flip(enemyStateManager));
        }

    }

    IEnumerator Flip(EnemyStateManager enemyStateManager)
    {
        yield return new WaitForSeconds(0f);
        enemyStateManager.isFlip = false;
        enemyStateManager.transform.parent.Rotate(0, 180, 0);
    }
}
