using UnityEngine;

namespace StatePattern.Enemy
{
    public class IdleState : IState
    {
        public EnemyController Owner { get; set; }
        private IStateMachine stateMachine;
        private float timer;

        public IdleState(IStateMachine stateMachine) => this.stateMachine = stateMachine;

        public void OnEnterState() => ResetTimer();

        public void UpdateState()
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                if (Owner.GetType() == typeof(OnePunchManController))
                {
                    stateMachine.ChangeState(State.ROTATING);
                }
                else
                {
                    stateMachine.ChangeState(State.PATROLLING);
                }
            }

        }

        public void OnExitState() => timer = 0;

        private void ResetTimer() => timer = Owner.Data.IdleTime;
    }
}


