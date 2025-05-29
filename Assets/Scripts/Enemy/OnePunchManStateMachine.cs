using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace StatePattern.Enemy
{
    public class OnePunchManStateMachine
    {
        private OnePunchManController Owner;
        protected Dictionary<OnePunchManStates, IState> States = new Dictionary<OnePunchManStates, IState>();

        private IState currentState;

        public OnePunchManStateMachine(OnePunchManController Owner)
        {
            this.Owner = Owner;
            CreateStates();
            SetOwner();
        }

        private void CreateStates()
        {
            States.Add(OnePunchManStates.IDLE, new IdleState(this));
            States.Add(OnePunchManStates.ROTATING, new RotatingState(this));
            States.Add(OnePunchManStates.SHOOTING, new ShootingState(this));
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

        public void ChangeState(OnePunchManStates newState) => ChangeState(States[newState]);

        private void SetOwner()
        {
            foreach (IState state in States.Values)
            {
                state.Owner = Owner;
            }
        }

    }
}

