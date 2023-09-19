using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyProjectile : MonoBehaviour
{
    private Vector3 moveDirection;
    private float damage;
    private float projectileSpeed;

    private void OnEnable()
    {
        moveDirection = Vector3.zero;
        damage = 0;
        projectileSpeed = 0;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (damage != 0 && projectileSpeed != 0)
        {
            transform.Translate(moveDirection * projectileSpeed * Time.deltaTime, Space.World);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth playerHit;
        if (other.TryGetComponent(out playerHit))
        {
            playerHit.ChangeHealth(damage);
        }
        gameObject.SetActive(false);
    }

    public void Initialize(Vector3 _moveDirection,float _damage, float _projectileSpeed)
    {
        moveDirection = _moveDirection;
        damage = _damage;
        projectileSpeed = _projectileSpeed;
    }
}
