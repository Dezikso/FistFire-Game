using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(EnemyStateMachine), typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    [Header("Sight Values")]
    [SerializeField] private float sightDistance = 10f;
    [SerializeField] private float fieldOfView = 75f;
    [SerializeField] private float eyeHeight = 1f;
    [Header("Weapon Values")]
    [Range(0.1f, 10f)] public float fireRate = 1f;
    [Header("Dodge Values")]
    [SerializeField] private float moveDistance = 5f;
    public float MoveDistance { get => moveDistance; }
    [Header("Search Values")]
    [SerializeField] private float searchTime = 5f;
    public float SearchTime { get => searchTime; }

    private EnemyStateMachine stateMachine;
    private NavMeshAgent agent;
    public NavMeshAgent Agent {get => agent;}
    private GameObject player;
    public GameObject Player { get => player; }
    private Vector3 lastKnownPos;
    public Vector3 LastKnownPos { get => lastKnownPos; set => lastKnownPos = value; }


    private void Start()
    {
        stateMachine = GetComponent<EnemyStateMachine>();
        agent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<PlayerHealth>().gameObject;

        stateMachine.Initialize();
    }


    public bool CanSeePlayer()
    {
        if (player != null)
        {
            if (Vector3.Distance(transform.position, player.transform.position) < sightDistance)
            {
                Vector3 targetDirection = player.transform.position - transform.position - (Vector3.up * eyeHeight);
                float angleToPlayer = Vector3.Angle(targetDirection, transform.forward);
                if (angleToPlayer >= -fieldOfView && angleToPlayer <= fieldOfView)
                {
                   Ray ray = new Ray (transform.position + (Vector3.up * eyeHeight), targetDirection);
                   RaycastHit hitInfo = new RaycastHit();
                    if (Physics.Raycast(ray, out hitInfo, sightDistance))
                    {
                        if (hitInfo.transform.gameObject == player)
                        {
                            Debug.DrawRay(ray.origin, ray.direction * sightDistance);
                            return true;
                        }
                    }
                }
            }
        }
        return false;
        
    }

}
