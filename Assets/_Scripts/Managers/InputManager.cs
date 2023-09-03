using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    #region Singleton
    public static InputManager Instance { get; private set; }
    private void InitializeSingleton()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    #endregion

    private PlayerInputActions playerInput;


    private void Awake() 
    {
        InitializeSingleton();
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

    public bool PunchedThisFrame()
    {
        return playerInput.Player.Punch.WasPerformedThisFrame();
    }

}
