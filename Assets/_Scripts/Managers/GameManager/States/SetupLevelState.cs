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
        gameManager.activePlatform = gameManager.platforms[gameManager.activePlatformId];

        foreach (GameObject platform in gameManager.platforms)
        {
            platform.SetActive(false);
        }

        gameManager.activePlatform.SetActive(true);
        gameManager.navMeshSurface.BuildNavMesh();
    }


}
