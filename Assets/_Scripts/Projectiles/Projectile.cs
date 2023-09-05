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



    private ProjectileData projectileData;
    private ProjectileState state = ProjectileState.idle;
    private Vector3 moveDirection;


    private void OnEnable()
    {
        projectileData = null;
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
            transform.Translate(moveDirection * projectileData.speed * Time.deltaTime, Space.World);
        }
    }


    public void InitializeStats(ProjectileData _projectileData)
    {
        this.projectileData = _projectileData;
    }

    public void OnPunch(Vector3 _moveDirection)
    {
        if (projectileData != null)
        {
            state = ProjectileState.active;
            moveDirection = _moveDirection;
        }
    }

}
