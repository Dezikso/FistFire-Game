using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController), typeof(InputManager), typeof(PlayerStatsManager))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float crouchHeight = 0.75f;
    [SerializeField] private float gravityValue = -9.81f;
    [SerializeField] private float dashDistance = 5f;
    [SerializeField] private float dashDuration = 0.5f;

    [Tooltip("Parent of all objects that need to be facing the same direction as playerfollowcamera")]
    [SerializeField] Transform cameraLook;

    private CharacterController controller;
    private CapsuleCollider playerCollider;
    private InputManager inputManager;
    private PlayerStats playerStats;
    private Transform cameraTransform;
    private float playerHeight;
    private Vector3 moveValue;
    private Vector3 velocity;
    private bool isCrouching;


    private void OnEnable()
    {
        PlayerStatsManager.onStatsChange += UpdateStats;
        PlayerHealth.onPlayerDeath += OnPlayerDeath;
    }

    private void OnDisable()
    {
        PlayerStatsManager.onStatsChange -= UpdateStats;
        PlayerHealth.onPlayerDeath -= OnPlayerDeath;
    }

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        inputManager = GetComponent<InputManager>();
        playerCollider = GetComponent<CapsuleCollider>();
        cameraTransform = Camera.main.transform;
        playerHeight = controller.height;
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        CalculateMovement();
        ApplyGravity();
        Jump();
        Dash();
        Crouch();
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
        if (inputManager.JumpedThisFrame())  
        {
            if (controller.isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravityValue);
            }
        }
    }

    private void Dash()
    {
        if (playerStats.nextDashTime > 0)
        {
            playerStats.nextDashTime -= Time.deltaTime;
        }

        if (inputManager.DashedThisFrame() && playerStats.nextDashTime <= 0)
        {
            Vector3 startPos = transform.position;
            Vector3 endPos = startPos + moveValue * dashDistance;

            float elapsedTime = 0f;

            while (elapsedTime < dashDuration)
            {
                controller.Move(moveValue * (dashDistance/dashDuration) * Time.deltaTime);
                elapsedTime += Time.deltaTime;
            }

            playerStats.nextDashTime = playerStats.dashCooldown;
        }
    }

    private void Crouch()
    {
        if (inputManager.IsCrouching())  
        {
            isCrouching = !isCrouching;

            if (isCrouching)
            {
                controller.height = crouchHeight;
                playerCollider.height = crouchHeight;
            }
            else
            {
                controller.height = playerHeight;
                playerCollider.height = playerHeight;
            }
        }
    }

    private void PerformMovement()
    {
        controller.Move(moveValue * Time.deltaTime * playerStats.speed);
        controller.Move(velocity * Time.deltaTime);
    }

    private void UpdateStats(PlayerStats stats)
    {
        playerStats = stats;
    }

    private void OnPlayerDeath()
    {
        gameObject.SetActive(false);
    }

}