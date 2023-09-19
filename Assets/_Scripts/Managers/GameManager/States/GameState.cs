public abstract class GameState
{
    public GameManager gameManager;
    public GameStateMachine stateMachine;

    public abstract void Enter();
    public abstract void Perform();
    public abstract void Exit();
}
