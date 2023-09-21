using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupLevelState : GameState
{
    public override void Enter()
    {
        gameManager.player.GetComponent<CharacterController>().enabled = false;

        ResetPlayerPosition();
        SetPlatforms();

        stateMachine.ChangeState(new CombatState());
    }

    public override void Exit()
    {
        gameManager.player.GetComponent<CharacterController>().enabled = true;
    }

    public override void Perform()
    {
        
    }


    private void ResetPlayerPosition()
    {
        gameManager.player.transform.position = gameManager.PlayerSpawn.position;
    }

    private void SetPlatforms()
    {
        for (int i = 0; i < gameManager.Platforms.Length; i++)
        {
            gameManager.Platforms[i].SetActive(false);
        }

        gameManager.Platforms[gameManager.activePlatformId].SetActive(true);
    }


}
