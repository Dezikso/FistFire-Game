using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController), typeof(InputManager))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 3.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;

    [Tooltip("Parent of all objects that need to be facing the same direction as playerfollowcamera")]
    [SerializeField] Transform cameraLook;

    private CharacterController controller;
    private InputManager inputManager;
    private Transform cameraTransform
;
    private Vector3 moveValue;
    private Vector3 velocity;


    private void Start()
    {
        controller = GetComponent<CharacterController>();
        inputManager = GetComponent<InputManager>();
        cameraTransform = Camera.main.transform;

        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        CalculateMovement();
        ApplyGravity();
        Jump();
        PerformMovement();
    }

    private void FixedUpdate()
    {
        UpdateCameraLook();
    }

    private void UpdateCameraLook()
    {
        cameraLook.rotation = cameraTransform.rotation;
    }

    private void CalculateMovement()
    {
        Vector2 movement = inputManager.GetPlayerMovement();
        moveValue = new Vector3(movement.x, 0f, movement.y);
        moveValue = cameraTransform.forward * moveValue.z + cameraTransform.right * moveValue.x;
        moveValue.y = 0f;
    }

    private void ApplyGravity()
    {
        velocity.y += gravityValue * Time.deltaTime;
    }

    private void Jump()
    {
        if (controller.isGrounded && inputManager.JumpedThisFrame())  
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravityValue);
        }
    }

    private void PerformMovement()
    {
        controller.Move(moveValue * Time.deltaTime * speed);
        controller.Move(velocity * Time.deltaTime);
    }

}