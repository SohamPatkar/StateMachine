using System.Collections;
using System.Collections.Generic;
using StatePattern.Player;
using UnityEngine;

namespace StatePattern.Enemy
{
    public class HitmanController : EnemyController
    {
        private HitmanStateMachine stateMachine;

        public HitmanController(EnemyScriptableObject enemyScriptableObject) : base(enemyScriptableObject)
        {
            enemyView.SetController(this);
            CreateStateMachine();
            stateMachine.ChangeState(State.IDLE);
        }

        private void CreateStateMachine() => stateMachine = new HitmanStateMachine(this);

        public override void UpdateEnemy()
        {
            if (currentState == EnemyState.DEACTIVE)
                return;

            stateMachine.Update();
        }

        public override void Shoot()
        {
            base.Shoot();
            stateMachine.ChangeState(State.TELEPORTING);
        }

        public override void PlayerEnteredRange(PlayerController targetToSet)
        {
            base.PlayerEnteredRange(targetToSet);
            stateMachine.ChangeState(State.CHASING);
        }

        public override void PlayerExitedRange() => stateMachine.ChangeState(State.IDLE);
    }
}


