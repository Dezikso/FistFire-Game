using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    public EnemyBaseState activeState;


    private void Update()
    {
        if (activeState != null)
        {
            activeState.Perform();
        }
    }

    public void Initialize()
    {
        //setup default state
    }

    public void ChangeState(EnemyBaseState newState)
    {
        if (activeState != null)
        {
            activeState.Exit();
        }

        activeState = newState;

        if (activeState != null)
        {
            activeState.stateMachine = this;
            activeState.Enter();
        }
    }
}
