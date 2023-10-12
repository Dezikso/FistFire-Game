using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Interactable
{
    private enum ProjectileState
    {
        entry,
        charge,
        idle,
        active,
        exit
    }

    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private float chargeTime = 1f;
    [SerializeField] private Material chargingMaterial;
    [SerializeField] private Material readyMaterial;

    private PlayerStats playerStats;
    private ProjectileState state;
    private Vector3 moveDirection;
    private float countdown;


    private void Awake()
    {
        PlayerStatsManager.onStatsChange += UpdateStats;
    }
    private void OnDestroy()
    {
        PlayerStatsManager.onStatsChange -= UpdateStats;
    }

    private void OnEnable()
    {
        meshRenderer.material = chargingMaterial;
        countdown = chargeTime;
        moveDirection = Vector3.zero;
        state = ProjectileState.entry;
    }

    private void UpdateStats(PlayerStats stats)
    {
        playerStats = stats;
    }

    private void Update()
    {
        switch (state)
        {
            case ProjectileState.entry:
                //spawn particles
                state = ProjectileState.charge;
                break;

            case ProjectileState.charge:
                countdown -= Time.deltaTime;
                if (countdown <= 0)
                {
                    meshRenderer.material = readyMaterial;
                    state = ProjectileState.idle;
                }
                break;

            case ProjectileState.idle:
                //idle animation
                break;

            case ProjectileState.active:
                Move();
                break;

            case ProjectileState.exit:
                //onDestroy particles
                gameObject.SetActive(false);
                break;
        }
    }


    private void Move()
    {
        if (moveDirection != null && playerStats != null)
        {
            transform.Translate(moveDirection * playerStats.projectileSpeed * Time.deltaTime, Space.World);
        }
    }

    protected override void Interact()
    {
        if (state == ProjectileState.idle)
        {
            moveDirection = Camera.main.transform.forward;
            state = ProjectileState.active;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (state == ProjectileState.active)
        {
            Enemy objectHit;
            if (other.TryGetComponent(out objectHit))
            {
                objectHit.ChangeHealth(playerStats.damage);
                state = ProjectileState.exit;
            }
            else
            {
                state = ProjectileState.exit;
            }
        }
    }

}
