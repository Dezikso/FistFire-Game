using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatState : GameState
{
    private Platform wave;

    public override void Enter()
    {
        wave = gameManager.activePlatform.GetComponent<Platform>();
    }

    public override void Exit()
    {
        
    }

    public override void Perform()
    {
        if (!wave.isCompleted)
        {
            if (wave.IsWaveReady())
            {
                wave.StartNewWave();
            }
        }
        else
        {
            Debug.Log("End");
            //stateMachine.ChangeState(new )
        }
    }

}
