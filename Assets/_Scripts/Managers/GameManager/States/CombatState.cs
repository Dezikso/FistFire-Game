using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class CombatState : GameState
{
    private Platform platform;
    private float startDelayTimer;

    public override void Enter()
    {
        platform = gameManager.activePlatform.GetComponent<Platform>();
    }

    public override void Exit()
    {
        
    }

    public override void Perform()
    {
        if (startDelayTimer >= 2)
        {
            if (!platform.isCompleted)
            {
                if (platform.IsWaveReady())
                {
                    platform.StartNewWave();
                }
            }
            else
            {
                stateMachine.ChangeState(new VictoryState());
            }
        }
        else
        {
            startDelayTimer += Time.deltaTime;
        }
    }

}
