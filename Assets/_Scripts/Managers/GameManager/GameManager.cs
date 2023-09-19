using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameStateMachine))]
public class GameManager : MonoBehaviour
{
    [SerializeField] private string activeState;

    private GameStateMachine stateMachine;
    //Various values related to different states
    //Maybe set up as a multiple scriptableObjects

    private void Awake()
    {
        stateMachine = GetComponent<GameStateMachine>();

        stateMachine.Initialize();
    }

    private void Update()
    {
        activeState = stateMachine.activeState.ToString();

    }

}
