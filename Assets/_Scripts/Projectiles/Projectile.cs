using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Projectile : Interactable
{
    private enum ProjectileState
    {
        entry,
        idle,
        active,
        exit
    }


    private PlayerStats playerStats;
    private ProjectileState state;
    private Vector3 moveDirection;


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
                state = ProjectileState.idle;
                break;
            case ProjectileState.idle:
                //
                break;
            case ProjectileState.active:
                Move();
                break;
            case ProjectileState.exit:
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
        }
    }

}
