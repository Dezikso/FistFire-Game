using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameStateMachine))]
public class GameManager : MonoBehaviour
{
    [SerializeField] private string activeState;
    [SerializeField] private Transform playerSpawn;     //replace with the one on platform

    public Transform PlayerSpawn { get => playerSpawn; }
    
    private GameStateMachine stateMachine;

    public GameObject activePlatform;
    public int activePlatformId;
    public GameObject player;
    public GameObject[] platforms;
    

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



