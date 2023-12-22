using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellIdleState : State
{
    public override void UpdateSate(EnemyStateManager enemyStateManager)
    {
        enemyStateManager.rb.velocity = Vector3.zero;
    }
}
