using System.Collections;
using System.Collections.Generic;
using StatePattern.Main;
using StatePattern.Player;
using UnityEngine;

namespace StatePattern.Enemy
{
    public class ClonerController : EnemyController
    {
        private ClonerStateMachine stateMachine;
        public int CloneCountLeft { get; private set; }

        public ClonerController(EnemyScriptableObject enemyScriptableObject) : base(enemyScriptableObject)
        {
            SetCloneCount(enemyScriptableObject.CloneCount);
            enemyView.SetController(this);
            ChangeColor(EnemyColorType.Default);
            CreateStateMachine();
            stateMachine.ChangeState(State.IDLE);
        }

        public void SetCloneCount(int cloneCountToSet) => CloneCountLeft = cloneCountToSet;

        private void CreateStateMachine() => stateMachine = new ClonerStateMachine(this);

        public override void UpdateEnemy()
        {
            if (currentState == EnemyState.DEACTIVE)
                return;

            stateMachine.Update();
        }

        public override void PlayerEnteredRange(PlayerController targetToSet)
        {
            base.PlayerEnteredRange(targetToSet);
            stateMachine.ChangeState(State.CHASING);
        }

        public override void PlayerExitedRange() => stateMachine.ChangeState(State.IDLE);

        public override void Die()
        {
            if (CloneCountLeft > 0)
            {
                stateMachine.ChangeState(State.CLONING);
            }

            base.Die();
        }

        public void Teleport() => stateMachine.ChangeState(State.TELEPORTING);

        public void SetDefaultColor(EnemyColorType colorType) => enemyView.SetDefaultColor(colorType);

        public void ChangeColor(EnemyColorType colorType) => enemyView.ChangeColor(colorType);
    }
}


