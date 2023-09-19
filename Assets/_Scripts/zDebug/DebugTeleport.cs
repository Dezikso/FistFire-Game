using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTeleport : Interactable
{
    [SerializeField] private Transform destination;
    private CharacterController playerCharacterController;

    private void Start()
    {
        PlayerController playerController = FindObjectOfType<PlayerController>();
        if (playerController != null)
        {
            playerCharacterController = playerController.GetComponent<CharacterController>();
        }
    }

    protected override void Interact() 
    {
        if (playerCharacterController != null)
        {
            playerCharacterController.enabled = false;
            playerCharacterController.transform.position = destination.position + new Vector3(2,0,0);
            playerCharacterController.enabled = true;
        }
    }

}
