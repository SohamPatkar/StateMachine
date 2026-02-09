using System.Collections;
using System.Collections.Generic;
using StatePattern.Enemy;
using StatePattern.Player;
using StatePattern.Main;
using UnityEngine;

namespace StatePattern.Enemy
{
    public class ChasingState<T> : IState where T : EnemyController
    {
        public EnemyController Owner { get; set; }
        private GenericStateMachine<T> stateMachine;
        private PlayerController target;

        public ChasingState(GenericStateMachine<T> stateMachine) => this.stateMachine = stateMachine;

        public void OnEnterState()
        {
            SetTarget();
            SetStoppingDistance();
        }

        public void UpdateState()
        {
            MoveTowardsTarget();
            if (ReachedTarget())
            {
                ResetPath();
                stateMachine.ChangeState(State.SHOOTING);
            }
        }

        public void OnExitState() => target = null;


        private void SetTarget() => target = GameService.Instance.PlayerService.GetPlayer();

        private void SetStoppingDistance() => Owner.Agent.stoppingDistance = Owner.Data.PlayerStoppingDistance;

        private bool MoveTowardsTarget() => Owner.Agent.SetDestination(target.Position);

        private bool ReachedTarget() => Owner.Agent.remainingDistance <= Owner.Agent.stoppingDistance;

        private void ResetPath()
        {
            Owner.Agent.isStopped = true;
            Owner.Agent.ResetPath();
        }
    }
}

