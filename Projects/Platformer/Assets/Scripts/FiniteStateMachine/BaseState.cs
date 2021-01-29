using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{
    protected StateActor<T> actor;
    protected StateMachine stateMachine;
    protected ActorData data;

    protected float startTime;

    private string animBoolName;

    public BaseState(StateActor actor, StateMachine stateMachine, ActorData data, string animBoolName)
    {
        this.actor = actor;
        this.stateMachine = stateMachine;
        this.data = data;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        DoChecks();
        actor.Anim.SetBool(animBoolName, true);
        startTime = Time.time;
    }

    public virtual void Exit()
    {
        actor.Anim.SetBool(animBoolName, false);
    }

    public virtual void DoChecks()
    {

    }

    public virtual void LogicUpdate()
    {
        //Update
    }

    public virtual void PhysicsUpdate()
    {
        //FixedUpdate
        DoChecks();
    }
}
