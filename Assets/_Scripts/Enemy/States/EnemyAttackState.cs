using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{
    private float dodgeTimer;
    private float looseSightTimer;
    private float shootTimer;


    public override void Enter()
    {
        
    }

    public override void Exit()
    {
        
    }

    public override void Perform()
    {
        if (enemy.CanSeePlayer())
        {
            looseSightTimer = 0;
            dodgeTimer += Time.deltaTime;
            shootTimer += Time.deltaTime;
            enemy.transform.LookAt(enemy.Player.transform);

            Shoot();
            Dodge();

            enemy.LastKnownPos = enemy.Player.transform.position;
        }
        else
        {
            looseSightTimer += Time.deltaTime;
            if (looseSightTimer > 5)
            {
                stateMachine.ChangeState(new EnemySearchState());
            }
        }
    }


    private void Shoot()
    {
        if (shootTimer > enemy.fireRate)
        {
            Debug.Log("Shoot");
            shootTimer = 0;
        }
    }

    private void Dodge()
    {
        if (dodgeTimer > Random.Range(2,6))
        {
            enemy.Agent.SetDestination(enemy.transform.position + (Random.insideUnitSphere * enemy.MoveDistance));
            dodgeTimer = 0;
        }
    }
}
