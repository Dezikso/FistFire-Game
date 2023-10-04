using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

[RequireComponent(typeof(EnemyStateMachine), typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform attackRoot;
    [SerializeField] private EnemyStats baseEnemyStats;

    private EnemyStateMachine stateMachine;
    private NavMeshAgent agent;
    private GameObject player;
    private PlayerStatsManager playerStatsManager;
    private float currentHealth;

    public Transform AttackRoot { get => attackRoot; }
    public NavMeshAgent Agent {get => agent;}
    public GameObject Player { get => player; }
    
    
    [HideInInspector] public EnemyStats enemyStats;
    [HideInInspector] public Vector3 lastKnownPos;


    private void Awake()
    {
        stateMachine = GetComponent<EnemyStateMachine>();
        agent = GetComponent<NavMeshAgent>();
        enemyStats = baseEnemyStats;

        playerStatsManager = FindObjectOfType<PlayerStatsManager>();
        player = playerStatsManager?.gameObject;

        stateMachine.Initialize();
    }

    private void OnEnable()
    {
        currentHealth = enemyStats.maxHealth;
        agent.speed = enemyStats.speed;
        transform.LookAt(player.transform);
    }
    private void OnDisable()
    {
        
    }

    private void Update()
    {
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

    // public void MultiplyDificulty(PlayerStats stats)
    // {
    //     float multiplier = stats.difficultyMultiplier;
    //     enemyStats.maxHealth *= multiplier;
    //     enemyStats.fireRate *= multiplier;
    //     enemyStats.damage *= multiplier;
    //     enemyStats.speed *= multiplier;
    // }

}
