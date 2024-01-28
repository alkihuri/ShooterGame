using System.Collections;
using System.Collections.Generic;
using CustomTools;
using UnityEngine;

public class GameStateMachine : MonoSinglethon<GameStateMachine>
{
    public GameState CurrentState { get; private set; }
    public GameState PreviousState { get; private set; }

    public StartGameState StartGameState { get; private set; }
    public OnGameState OnGameState { get; private set; }

    public DataContainer CurrentGameData;

    public void Innit(DataContainer data)
    {
        CurrentGameData = data;
    }
    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        StartGameState = new StartGameState();
        OnGameState = new OnGameState();




        ChangeState(StartGameState);
    }

    public void ChangeState(GameState newState)
    {
        if (CurrentState != null)
        {
            CurrentState.Exit(this);
        }

        PreviousState = CurrentState;
        CurrentState = newState;
        CurrentState.Enter(this);
    }
    public void Update()
    {
        if (CurrentState != null)
        {
            CurrentState.Update(this);
        }
    }

}
