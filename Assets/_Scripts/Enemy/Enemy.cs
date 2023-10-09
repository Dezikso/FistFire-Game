using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

[RequireComponent(typeof(EnemyStateMachine), typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform attackRoot;
    [SerializeField] private EnemyStats baseEnemyStats;
    [SerializeField] private LayerMask playerLayer;

    private EnemyStateMachine stateMachine;
    private NavMeshAgent agent;
    private GameObject player;
    private PlayerStatsManager playerStatsManager;
    private float currentHealth;
    private float difficultyMultiplier = 1.1f;

    public Transform AttackRoot { get => attackRoot; }
    public NavMeshAgent Agent { get => agent; }
    public GameObject Player { get => player; }
      
    [HideInInspector] public EnemyStats enemyStats;
    [HideInInspector] public Vector3 lastKnownPos;


    private void Awake()
    {
        GameManager.onNextLevel += UpdateDificulty;

        stateMachine = GetComponent<EnemyStateMachine>();
        agent = GetComponent<NavMeshAgent>();
        enemyStats = EnemyStats.CreateInstance(baseEnemyStats);

        playerStatsManager = FindObjectOfType<PlayerStatsManager>();
        player = playerStatsManager?.gameObject;

        stateMachine.Initialize();
    }

    private void OnDestroy()
    {
        GameManager.onNextLevel -= UpdateDificulty;
    }

    private void OnEnable()
    {
        currentHealth = enemyStats.maxHealth;
        agent.speed = enemyStats.speed;
        transform.LookAt(player.transform);
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }

        if (Keyboard.current.lKey.wasPressedThisFrame)
        {
            UpdateDificulty();
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
                    if (Physics.Raycast(ray, out hitInfo, enemyStats.sightDistance, playerLayer))
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

    private void UpdateDificulty()
    {
        enemyStats.maxHealth *= difficultyMultiplier;
        enemyStats.fireRate *= difficultyMultiplier;
        enemyStats.damage *= difficultyMultiplier;
        enemyStats.speed *= difficultyMultiplier; 

        if (enemyStats.maxDodgeInterval > 0.5f)
        {
            enemyStats.maxDodgeInterval /= difficultyMultiplier;
        }   
    }

}
