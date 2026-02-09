using System.Collections;
using System.Collections.Generic;
using StatePattern.Enemy;
using UnityEngine;
using UnityEngine.AI;

namespace StatePattern.Enemy
{
    public class TeleportState<T> : IState where T : EnemyController
    {
        public EnemyController Owner { get; set; }
        private GenericStateMachine<T> stateMachine;

        public TeleportState(GenericStateMachine<T> stateMachine) => this.stateMachine = stateMachine;

        public void OnEnterState()
        {
            TravelToPosition();
        }

        public void TravelToPosition()
        {
            Owner.Agent.Warp(GetRandomPosition());
        }

        private Vector3 GetRandomPosition()
        {
            Vector3 randomDirection = Random.insideUnitSphere * Owner.Data.RangeRadius + Owner.Position;
            NavMeshHit hit;

            if (NavMesh.SamplePosition(randomDirection, out hit, Owner.Data.RangeRadius, NavMesh.AllAreas))
            {
                return hit.position;
            }

            return Owner.Data.SpawnPosition;
        }

        public void OnExitState() { }

        public void UpdateState() { }
    }
}


