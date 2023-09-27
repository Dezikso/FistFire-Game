using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

[RequireComponent(typeof(GameStateMachine))]
public class GameManager : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private string activeState;
    [SerializeField] public NavMeshSurface navMeshSurface;  
    [Header("Platforms")]
    [SerializeField] public GameObject[] platforms;   
    
    
    [HideInInspector] public GameStateMachine stateMachine;
    [HideInInspector] public GameObject activePlatform;
    [HideInInspector] public int activePlatformId;
    [HideInInspector] public GameObject player;
    

    private void OnEnable()
    {
        PlayerHealth.onPlayerDeath += GameOver;
    }

    private void OnDisable()
    {
        PlayerHealth.onPlayerDeath -= GameOver;
    }

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

    private void GameOver()
    {
        stateMachine.ChangeState(new GameOverState());
    }

}



