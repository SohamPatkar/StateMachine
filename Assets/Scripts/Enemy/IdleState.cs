using UnityEngine;

namespace StatePattern.Enemy
{
    public class IdleState : IState
    {
        public OnePunchManController Owner { get; set; }
        private OnePunchManStateMachine stateMachine;
        private float timer;

        public IdleState(OnePunchManStateMachine stateMachine) => this.stateMachine = stateMachine;

        public void OnEnterState() => ResetTimer();

        public void UpdateState()
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
                stateMachine.ChangeState(OnePunchManStates.ROTATING);
        }

        public void OnExitState() => timer = 0;

        private void ResetTimer() => timer = Owner.Data.IdleTime;
    }
}


