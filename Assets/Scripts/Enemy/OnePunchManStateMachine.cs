using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace StatePattern.Enemy
{
    public class OnePunchManStateMachine : IStateMachine
    {
        private OnePunchManController Owner;
        protected Dictionary<State, IState> States = new Dictionary<State, IState>();

        private IState currentState;

        public OnePunchManStateMachine(OnePunchManController Owner)
        {
            this.Owner = Owner;
            CreateStates();
            SetOwner();
        }

        private void CreateStates()
        {
            States.Add(State.IDLE, new IdleState(this));
            States.Add(State.ROTATING, new RotatingState(this));
            States.Add(State.SHOOTING, new ShootingState(this));
        }

        public void Update()
        {
            currentState?.UpdateState();
        }

        protected void ChangeState(IState newState)
        {
            currentState?.OnExitState();
            currentState = newState;
            currentState?.OnEnterState();
        }

        public void ChangeState(State newState) => ChangeState(States[newState]);

        private void SetOwner()
        {
            foreach (IState state in States.Values)
            {
                state.Owner = Owner;
            }
        }

    }
}

