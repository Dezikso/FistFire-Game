using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

[RequireComponent(typeof(EnemyStateMachine), typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private string activeState;
    [SerializeField] private Transform attackRoot;
    public Transform AttackRoot { get => attackRoot; }

    private EnemyStateMachine stateMachine;
    private NavMeshAgent agent;
    public NavMeshAgent Agent {get => agent;}
    private GameObject player;
    public GameObject Player { get => player; }
    private Vector3 lastKnownPos;
    public Vector3 LastKnownPos { get => lastKnownPos; set => lastKnownPos = value; }
    private float currentHealth;

    public EnemyStats enemyStats;


    private void Awake()
    {
        stateMachine = GetComponent<EnemyStateMachine>();
        agent = GetComponent<NavMeshAgent>();

        PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
        player = playerHealth?.gameObject;

        stateMachine.Initialize();
    }

    private void OnEnable()
    {
        currentHealth = enemyStats.maxHealth;
        agent.speed = enemyStats.speed;
        transform.LookAt(player.transform);
    }

    private void Update()
    {
        activeState = stateMachine.activeState.ToString();

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
        
    }

    public bool CanSeePlayer()
    {
        if (player != null)
        {
            if (Vector3.Distance(transform.position, player.transform.position) < enemyStats.sightDistance)
            {
                Vector3 targetDirection = player.transform.position - transform.position - (Vector3.up * enemyStats.eyeHeight);
                float angleToPlayer = Vector3.Angle(targetDirection, transform.forward);
                if (angleToPlayer >= -enemyStats.fieldOfView && angleToPlayer <= enemyStats.fieldOfView)
                {
                   Ray ray = new Ray (transform.position + (Vector3.up * enemyStats.eyeHeight), targetDirection);
                   RaycastHit hitInfo = new RaycastHit();
                    if (Physics.Raycast(ray, out hitInfo, enemyStats.sightDistance))
                    {
                        if (hitInfo.transform.gameObject == player)
                        {
                            return true;
                        }
                    }
                }
            }
        }
        return false;
        
    }

    public void ChangeHealth(float healthChange)
    {
        currentHealth -= healthChange;
        //Debug.Log(currentHealth);
    }

}
