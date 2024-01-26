public abstract class GameState
{
    public abstract void Enter(GameStateMachine stateMachine); //DI :))))

    public abstract void Exit(GameStateMachine stateMachine);

    public abstract void Update(GameStateMachine stateMachine);
}
