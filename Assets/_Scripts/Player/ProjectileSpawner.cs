using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] private Transform projectileRoot;

    private InputManager inputManager;
    private PoolManager poolManager;


    private void Start()
    {
        inputManager = InputManager.Instance;
        poolManager = PoolManager.Instance;
    }

    private void Update()
    {
        SpawnProjectile();
    }


    private void SpawnProjectile()
    {
        if (inputManager.SpawnedProjectileThisFrame())
        {
            GameObject spawnedProjectile = poolManager.SpawnFromPool(PoolType.Projectile, projectileRoot.position, projectileRoot.rotation);
        }
    }
}
