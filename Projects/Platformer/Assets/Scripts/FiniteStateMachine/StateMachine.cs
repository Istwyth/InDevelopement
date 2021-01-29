using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{

    public BaseState CurrentState { get; private set; }

    public StateMachine(BaseState startingState)
    {
        CurrentState = startingState;
        CurrentState.Enter();
    }

    public void ChangeState(BaseState newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }
}
