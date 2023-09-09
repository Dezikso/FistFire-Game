using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerInputActions playerInput;


    private void Awake() 
    {
        playerInput = new PlayerInputActions();
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }


    public Vector2 GetPlayerMovement()
    {
        return playerInput.Player.Movement.ReadValue<Vector2>();
    }

    public bool JumpedThisFrame()
    {
        return playerInput.Player.Jump.WasPerformedThisFrame();
    }

    public bool SpawnedProjectileThisFrame()
    {
        return playerInput.Player.SpawnProjectile.WasPerformedThisFrame();
    }

    public bool InteractedThisFrame()
    {
        return playerInput.Player.Interact.WasPerformedThisFrame();
    }

}
