using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager _instance;
    public static InputManager Instance
    {
        get { return _instance; }
    }

    private PlayerInputActions playerInput;


    private void Awake() 
    {
        //Singleton
        if(_instance != null && _instance != this)
        {
            Destroy(this);
        }
        else
        {
            _instance = this;
        }

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

    public Vector2 GetMouseDelta()
    {
        return playerInput.Player.Look.ReadValue<Vector2>();
    }

    public bool JumpedThisFrame()
    {
        return playerInput.Player.Jump.WasPerformedThisFrame();
    }

    public bool SpawnedProjectileThisFrame()
    {
        return playerInput.Player.SpawnProjectile.WasPerformedThisFrame();
    }

}
