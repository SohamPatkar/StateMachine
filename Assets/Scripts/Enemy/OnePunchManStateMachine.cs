using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace StatePattern.Enemy
{
    public class OnePunchManStateMachine : GenericStateMachine<OnePunchManController>
    {
        public OnePunchManStateMachine(OnePunchManController Owner) : base(Owner)
        {
            this.Owner = Owner;
            CreateStates();
            SetOwner();
        }

        private void CreateStates()
        {
            States.Add(State.IDLE, new IdleState<OnePunchManController>(this));
            States.Add(State.ROTATING, new RotatingState<OnePunchManController>(this));
            States.Add(State.SHOOTING, new ShootingState<OnePunchManController>(this));
        }
    }
}

