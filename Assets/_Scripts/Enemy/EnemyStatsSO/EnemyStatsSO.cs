using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="EnemyStats", menuName ="ScriptableObjects/EnemyStats")]
public class EnemyStats : ScriptableObject
{
    [Header("Base Stats")]
    public float maxHealth = 100f;

    [Header("Sight Values")]
    public float sightDistance = 20f;
    public float fieldOfView = 85f;
    public float eyeHeight = 1f;

    [Header("Weapon Values")]
    public float fireRate = 1f;
    public float damage = 10f;
    public float projectileSpeed = 5f;
    public PoolType projectileType = PoolType.EnemyProjectile1;

    [Header("Dodge Values")]
    public float stepDistance = 5f;
    public float searchTime = 5f;

    [Header("Agent Settings")]
    public float speed = 3.5f;

}
