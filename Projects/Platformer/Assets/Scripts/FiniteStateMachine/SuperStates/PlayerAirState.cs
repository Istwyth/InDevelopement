using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirState : BaseState
{
    public PlayerAirState(StateActor actor, StateMachine stateMachine, PlayerData data, string animBoolName) : base(actor, stateMachine, data, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
