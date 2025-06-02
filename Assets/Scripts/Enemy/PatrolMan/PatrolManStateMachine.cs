using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatePattern.Enemy
{
    public class PatrolManStateMachine : GenericStateMachine<PatrolManController>
    {
        public PatrolManStateMachine(PatrolManController Owner) : base(Owner)
        {
            this.Owner = Owner;
            CreateStates();
            SetOwner();
        }

        private void CreateStates()
        {
            States.Add(State.IDLE, new IdleState<PatrolManController>(this));
            States.Add(State.PATROLLING, new PatrolState<PatrolManController>(this));
            States.Add(State.CHASING, new ChasingState<PatrolManController>(this));
            States.Add(State.SHOOTING, new ShootingState<PatrolManController>(this));
        }
    }
}


