using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="EnemyStats", menuName ="ScriptableObjects/EnemyStats")]
public class EnemyStats : ScriptableObject
{
    [Header("Base Stats")]
    public float maxHealth = 100f;

    [Header("Sight Values")]
    public float sightDistance = 25f;
    public float fieldOfView = 85f;
    public float eyeHeight = 1f;

    [Header("Weapon Values")]
    public float fireRate = 1f;
    public float damage = 10f;
    public float projectileSpeed = 5f;
    public PoolType projectileType = PoolType.EnemyProjectile1;

    [Header("Dodge Values")]
    public float minDodgeInterval = 1f;
    public float maxDodgeInterval = 6f;
    public float stepDistance = 5f;
    public float searchTime = 5f;

    [Header("Agent Settings")]
    public float speed = 3.5f;
    

    private void Initialize(EnemyStats _enemyStats)
    {
        this.maxHealth = _enemyStats.maxHealth;

        this.sightDistance = _enemyStats.sightDistance;
        this.fieldOfView = _enemyStats.fieldOfView;
        this.eyeHeight = _enemyStats.eyeHeight
        ;
        this.fireRate = _enemyStats.fireRate;
        this.damage = _enemyStats.damage;
        this.projectileSpeed = _enemyStats.projectileSpeed;
        this.projectileType = _enemyStats.projectileType;
        
        this.minDodgeInterval = _enemyStats.minDodgeInterval;
        this.maxDodgeInterval = _enemyStats.maxDodgeInterval;
        this.stepDistance = _enemyStats.stepDistance;
        this.searchTime = _enemyStats.searchTime;

        this.speed = _enemyStats.speed;
    }

    public static EnemyStats CreateInstance(EnemyStats _enemyStats)
    {
        var data = CreateInstance<EnemyStats>();
        data.Initialize(_enemyStats);
        return data; 
    }

}
