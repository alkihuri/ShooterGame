public abstract class GameState
{
    public abstract void Enter(GameStateMachine stateMachine);  

    public abstract void Exit(GameStateMachine stateMachine);

    public abstract void Update(GameStateMachine stateMachine);
}
