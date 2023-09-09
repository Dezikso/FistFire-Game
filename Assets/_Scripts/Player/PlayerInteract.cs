using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputManager), typeof(PlayerStatsManager))]
public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private LayerMask mask;
    [SerializeField] private float distance;

    private InputManager inputManager;
    private Transform cameraTransform;


    private void Start()
    {
        inputManager = GetComponent<InputManager>();
        cameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        HandleInteractions();
    }

    private void HandleInteractions()
    {
        if(inputManager.InteractedThisFrame())
        {   
            CheckRaycastHit();
        }
    }

    private void CheckRaycastHit()
    {
        Ray ray = new Ray(cameraTransform.position, cameraTransform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            if (hitInfo.collider.gameObject.GetComponent<Interactable>() != null)
            {
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();

                interactable.BaseInteract();
            }
        }
    }

}
