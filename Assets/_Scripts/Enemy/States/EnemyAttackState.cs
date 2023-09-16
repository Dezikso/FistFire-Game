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
            enemy.transform.LookAt(enemy.Player.transform);
            looseSightTimer = 0;
            dodgeTimer += Time.deltaTime;
            shootTimer += Time.deltaTime;
            
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
        if (shootTimer > enemy.enemyStats.fireRate)
        {
            Vector3 spawnPos = enemy.transform.position + enemy.transform.forward * 1.5f;
            GameObject poolObject = PoolManager.Instance.SpawnFromPool(enemy.enemyStats.projectileType, spawnPos, enemy.transform.rotation);
            poolObject.GetComponent<EnemyProjectile>().Initialize(enemy.transform.forward, -enemy.enemyStats.damage, enemy.enemyStats.projectileSpeed);

            shootTimer = 0;
        }
    }



    private void Dodge()
    {
        if (dodgeTimer > Random.Range(2,6))
        {
            enemy.Agent.SetDestination(enemy.transform.position + (Random.insideUnitSphere * enemy.enemyStats.stepDistance));
            dodgeTimer = 0;
        }
    }
}
