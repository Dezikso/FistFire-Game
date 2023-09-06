using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Projectile : MonoBehaviour
{
    private enum ProjectileState
    {
        idle,
        active,
        impact
    }


    private ProjectileStats projectileStats;
    private ProjectileState state = ProjectileState.idle;
    private Vector3 moveDirection;


    private void Awake()
    {
        projectileStats = PlayerStatsManager.Instance.ProjectileStats;
    }

    private void OnEnable()
    {
        moveDirection = Vector3.zero;
        state = ProjectileState.idle;
    }

    private void Update()
    {
        switch (state)
        {
            case ProjectileState.idle:
                Idle();
                break;
            case ProjectileState.active:
                Active();
                break;
            case ProjectileState.impact:
                Impact();
                break;
        }
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

    private void Impact()
    {
        Debug.Log(state);
    }


    private void Move()
    {
        if (moveDirection != null)
        {
            transform.Translate(moveDirection * projectileStats.speed * Time.deltaTime, Space.World);
        }
    }

    public void OnPunch(Vector3 _moveDirection)
    {   
        state = ProjectileState.active;
        moveDirection = _moveDirection;
    }

}
