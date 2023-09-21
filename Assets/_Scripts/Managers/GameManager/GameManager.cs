using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameStateMachine))]
public class GameManager : MonoBehaviour
{
    [SerializeField] private string activeState;
    [SerializeField] private GameObject[] platforms;
    [SerializeField] private Transform playerSpawn;
    public GameObject[] Platforms { get => platforms; }
    public Transform PlayerSpawn { get => playerSpawn; }
    
    private GameStateMachine stateMachine;
    
    public int activePlatformId;
    public GameObject player;
    

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



