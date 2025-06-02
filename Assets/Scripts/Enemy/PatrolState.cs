using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatePattern.Enemy
{
    public class PatrolState : IState
    {
        public EnemyController Owner { get; set; }
        private IStateMachine stateMachine;
        private int currentPatrollingIndex = -1;
        private Vector3 destination;

        public PatrolState(IStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }

        public void OnEnterState()
        {
            SetNextWaypointIndex();
            destination = GetDestination();
            MoveTowardsDestination();
        }

        private void SetNextWaypointIndex()
        {
            if (currentPatrollingIndex == Owner.Data.PatrollingPoints.Count - 1)
            {
                currentPatrollingIndex = 0;
            }
            else
            {
                currentPatrollingIndex++;
            }
        }

        private Vector3 GetDestination() => Owner.Data.PatrollingPoints[currentPatrollingIndex];

        private void MoveTowardsDestination()
        {
            Owner.Agent.isStopped = false;
            Owner.Agent.SetDestination(destination);
        }

        public void OnExitState()
        {
            Owner.Agent.isStopped = true;
        }

        public void UpdateState()
        {
            if (ReachedDestination())
            {
                stateMachine.ChangeState(State.IDLE);
            }
        }

        private bool ReachedDestination() => Owner.Agent.remainingDistance <= Owner.Agent.stoppingDistance;

    }
}


