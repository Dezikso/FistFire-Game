using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryState : GameState
{
    private Platform platform;

    public override void Enter()
    {
        platform = gameManager.activePlatform.GetComponent<Platform>();
        platform.portals.SetActive(true);
        platform.chest.SetActive(true);
        gameManager.OnNextLevel();

        SetupChest();
    }

    public override void Exit()
    {
        
    }

    public override void Perform()
    {
        
    }

    private void SetupChest()
    {
        platform.chest.GetComponent<Chest>().PlayerStatsManager = gameManager.player;
    }
}
