using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputManager), typeof(PlayerStatsManager))]
public class Punch : MonoBehaviour
{
    [SerializeField] private LayerMask mask;
    [SerializeField] private float distance;

    private InputManager inputManager;
    private PlayerStats playerStats;
    private Transform cameraTransform;


    private void Start()
    {
        inputManager = GetComponent<InputManager>();
        playerStats = GetComponent<PlayerStatsManager>().PlayerStats;
        cameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        HandleInteractions();
    }

    private void HandleInteractions()
    {
        if(inputManager.PunchedThisFrame())
        {
            
            //TODO IMPLEMENT INTERACTION SYSTEM BASED ON OBEJCT HIT
            //START OF DEBUG
            
            Projectile projectile;
            GameObject hitObject = CheckRaycastHit();

            if (hitObject != null)
            {
                if (projectile = hitObject.GetComponent<Projectile>())
                {
                    projectile.OnPunch(cameraTransform.forward, playerStats);
                }
            }

            //END OF DEBUG

        }
    }

    private GameObject CheckRaycastHit()
    {
        Ray ray = new Ray(cameraTransform.position, cameraTransform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            return hitInfo.collider.gameObject;
        }
        else
        {
            return null;
        }
    }

}
