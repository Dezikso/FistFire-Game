using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Portal : Interactable
{
    private GameManager gameManager;
    private int platformId;
    

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();    
    }

    private void OnEnable()
    {
        Initialize();
    }

    protected override void Interact()
    {
        gameManager.activePlatformId = platformId;
        gameManager.stateMachine.ChangeState(new SetupLevelState());
    }

    private void Initialize()
    {
        int maxRange = gameManager.platforms.Length - 1;
        platformId = UnityEngine.Random.Range(0, maxRange);

        SetAppearance();
    }

    private void SetAppearance()
    {
        Material material = gameManager.platforms[platformId].GetComponent<Platform>().portalMaterial;
        gameObject.GetComponentInChildren<MeshRenderer>().material = material;
    }

}
