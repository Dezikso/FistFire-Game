using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

[RequireComponent(typeof(GameStateMachine))]
public class GameManager : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private string activeState;
    [SerializeField] private Transform playerSpawn;     //replace with the one on platform
    public Transform PlayerSpawn { get => playerSpawn; }
    [SerializeField] public NavMeshSurface navMeshSurface;  
    [Header("Platforms")]
    [SerializeField] public GameObject[] platforms;   
    
    private GameStateMachine stateMachine;

    [HideInInspector] public GameObject activePlatform;
    [HideInInspector] public int activePlatformId;
    [HideInInspector] public GameObject player;
    

    private void Awake()
    {
        stateMachine = GetComponent<GameStateMachine>();
        PlayerController playerController = FindObjectOfType<PlayerController>();
        player = playerController?.gameObject;

        stateMachine.Initialize();
    }

    private void Update()
    {
        activeState = stateMachine.activeState.ToString();
    }

}



