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

    private void OnEnable()
    {
        moveDirection = Vector3.zero;
        ChangeState(ProjectileState.entry);
    }

    private void Update()
    {
        switch (state)
        {
            case ProjectileState.entry:
                Entry();
                break;
            case ProjectileState.idle:
                Idle();
                break;
            case ProjectileState.active:
                Active();
                break;
            case ProjectileState.exit:
                Exit();
                break;
        }
    }

    void ChangeState(ProjectileState _state)
    {
        state = _state;
    }

    #region States execution
    private void Entry()
    {
        Debug.Log(state);
        ChangeState(ProjectileState.idle);
    }

    private void Idle()
    {
        Debug.Log(state);
    }

    private void Active()
    {
        Debug.Log(state);
        Move();
    }

    private void Exit()
    {
        Debug.Log(state);
    }
    #endregion States execution


    private void Move()
    {
        if (moveDirection != null && playerStats != null)
        {
            transform.Translate(moveDirection * playerStats.projectileSpeed * Time.deltaTime, Space.World);
        }
    }

    private void UpdateStats(PlayerStats stats)
    {
        playerStats = stats;
    }

    protected override void Interact()
    {
        if (state == ProjectileState.idle)
        {
            moveDirection = Camera.main.transform.forward;
            ChangeState(ProjectileState.active);
        }
    }

}
