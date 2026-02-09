using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace StatePattern.Enemy
{
    public class ClonerStateMachine : GenericStateMachine<ClonerController>
    {
        public ClonerStateMachine(ClonerController Owner) : base(Owner)
        {
            this.Owner = Owner;
            CreateStates();
            SetOwner();
        }

        private void CreateStates()
        {
            States.Add(State.IDLE, new IdleState<ClonerController>(this));
            States.Add(State.PATROLLING, new PatrolState<ClonerController>(this));
            States.Add(State.CLONING, new CloningState<ClonerController>(this));
            States.Add(State.CHASING, new ChasingState<ClonerController>(this));
            States.Add(State.SHOOTING, new ShootingState<ClonerController>(this));
            States.Add(State.TELEPORTING, new TeleportState<ClonerController>(this));
        }
    }
}


