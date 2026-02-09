using System.Collections;
using System.Collections.Generic;
using StatePattern.Enemy;
using UnityEngine;

public class GenericStateMachine<T> where T : EnemyController
{
    private T Owner;
    private IState currentState;
    protected Dictionary<State, IState> States = new Dictionary<State, IState>();

    public GenericStateMachine(T Owner)
    {
        this.Owner = Owner;
    }

    private void SetOwner()
    {
        foreach (IState state in States.Values)
        {
            state.Owner = Owner;
        }
    }

    public void Update() => currentState?.UpdateState();

    protected void ChangeState(IState newState)
    {
        currentState?.OnExitState();
        currentState = newState;
        currentState?.OnEnterState();
    }

    public void ChangeState(State newState) => ChangeState(States[newState]);

}
