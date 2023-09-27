using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverState : GameState
{
    public override void Enter()
    {
        Debug.Log("You Died!");
    }

    public override void Exit()
    {
        
    }

    public override void Perform()
    {
        
    }
}
