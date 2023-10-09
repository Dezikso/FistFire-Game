using System;
using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

[RequireComponent(typeof(GameStateMachine))]
public class GameManager : MonoBehaviour
{
    [SerializeField] private string activeState;
    
    public NavMeshSurface navMeshSurface;  
    public GameObject[] platforms;   
    
    [HideInInspector] public GameStateMachine stateMachine;
    [HideInInspector] public GameObject activePlatform;
    [HideInInspector] public int activePlatformId;
    [HideInInspector] public GameObject player;

    public static Action onNextLevel;

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

    public void OnNextLevel()
    {
        onNextLevel?.Invoke();
    }

}



