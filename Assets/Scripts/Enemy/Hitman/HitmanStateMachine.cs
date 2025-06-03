using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatePattern.Enemy
{
    public class HitmanStateMachine : GenericStateMachine<HitmanController>
    {
        public HitmanStateMachine(HitmanController Owner) : base(Owner)
        {
            this.Owner = Owner;
            CreateStates();
            SetOwner();
        }

        private void CreateStates()
        {
            States.Add(State.IDLE, new IdleState<HitmanController>(this));
            States.Add(State.PATROLLING, new PatrolState<HitmanController>(this));
            States.Add(State.CHASING, new ChasingState<HitmanController>(this));
            States.Add(State.SHOOTING, new ShootingState<HitmanController>(this));
            States.Add(State.TELEPORTING, new TeleportState<HitmanController>(this));
        }
    }
}


