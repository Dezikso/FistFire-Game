using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupLevelState : GameState
{
    public override void Enter()
    {
        gameManager.player.GetComponent<CharacterController>().enabled = false;

        SetPlatform();
        ResetPlayerPosition();

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
        Platform platform = gameManager.activePlatform.GetComponent<Platform>();
        gameManager.player.transform.position = platform.playerSpawn.position;
    }

    private void SetPlatform()
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
