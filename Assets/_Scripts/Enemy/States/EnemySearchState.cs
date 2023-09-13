using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySearchState : EnemyBaseState
{
    private float searchTimer;
    private float moveTimer;


    public override void Enter()
    {
        enemy.Agent.SetDestination(enemy.LastKnownPos);
    }

    public override void Exit()
    {
    }

    public override void Perform()
    {
        if (enemy.CanSeePlayer())
        {
            stateMachine.ChangeState(new EnemyAttackState());
        }

        if (enemy.Agent.remainingDistance < enemy.Agent.stoppingDistance)
        {
            searchTimer += Time.deltaTime;
            moveTimer += Time.deltaTime;

            Move();

            if (searchTimer > enemy.SearchTime)
            {
                stateMachine.ChangeState(new EnemyIdleState());
            }
        }
    }

    private void Move()
    {
        if (moveTimer > Random.Range(2,6))
        {
            enemy.Agent.SetDestination(enemy.transform.position + (Random.insideUnitSphere * enemy.MoveDistance));
            moveTimer = 0;
        }
    }

}
