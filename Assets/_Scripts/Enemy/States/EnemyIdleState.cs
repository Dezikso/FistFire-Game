using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyBaseState
{
    public override void Enter()
    {
        
    }

    public override void Exit()
    {
        
    }

    public override void Perform()
    {
        Debug.Log("Idling and stuff");
        if (enemy.CanSeePlayer())
        {
            stateMachine.ChangeState(new EnemyAttackState());
        }
    }
}
