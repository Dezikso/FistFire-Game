using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputManager))]
public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] private Transform projectileRoot;

    private PoolManager poolManager;
    private InputManager inputManager;


    private void Start()
    {
        poolManager = PoolManager.Instance;
        inputManager = GetComponent<InputManager>();
    }

    private void Update()
    {
        SpawnProjectile();
    }


    private void SpawnProjectile()
    {
        if (inputManager.SpawnedProjectileThisFrame())
        {
            GameObject poolObject = poolManager.SpawnFromPool(PoolType.Projectile, projectileRoot.position, projectileRoot.rotation);
        }
    }
}
