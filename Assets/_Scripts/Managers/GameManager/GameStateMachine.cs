using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine : MonoBehaviour
{
    public GameState activeState;

    public void Initialize()
    {
        ChangeState(new SetupLevelState());
    }

    private void Update()
    {
        if (activeState != null)
        {
            activeState.Perform();
        } 
    }

    public void ChangeState(GameState newState)
    {
        if (activeState != null)
        {
            activeState.Exit();
        }

        activeState = newState;

        if (activeState != null)
        {
            activeState.stateMachine = this;
            activeState.gameManager = GetComponent<GameManager>();
            activeState.Enter();
        }
    }

}
