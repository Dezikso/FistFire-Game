using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] Transform projectileRoot;

    private InputManager inputManager;


    private void Start()
    {
        inputManager = InputManager.Instance;
    }

    private void Update()
    {
        SpawnProjectile();
    }


    private void SpawnProjectile()
    {
        if (inputManager.SpawnedProjectileThisFrame())
        {
            Debug.Log("Spawned a projectile at: " + projectileRoot);
        }
    }
}
