using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTeleport : Interactable
{
    [SerializeField] private Transform destination;
    private CharacterController player;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>().GetComponent<CharacterController>();
    }

    protected override void Interact() 
    {
        player.enabled = false;
        player.transform.position = destination.position + new Vector3(2,0,0);
        player.enabled = true;
    }

}
