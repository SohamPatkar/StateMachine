using System.Collections;
using System.Collections.Generic;
using StatePattern.Enemy;
using StatePattern.Main;
using UnityEngine;

namespace StatePattern.Enemy
{
    public class CloningState<T> : IState where T : EnemyController
    {
        public EnemyController Owner { get; set; }
        private GenericStateMachine<T> stateMachine;

        public CloningState(GenericStateMachine<T> stateMachine) => this.stateMachine = stateMachine;

        public void OnEnterState()
        {
            CreateAClone();
            CreateAClone();
        }

        public void OnExitState()
        {

        }

        public void UpdateState()
        {

        }

        private void CreateAClone()
        {
            ClonerController clonedRobot = GameService.Instance.EnemyService.CreateEnemy(Owner.Data) as ClonerController;
            clonedRobot.SetCloneCount((Owner as ClonerController).CloneCountLeft - 1);
            clonedRobot.Teleport();
            clonedRobot.SetDefaultColor(EnemyColorType.Clone);
            clonedRobot.ChangeColor(EnemyColorType.Clone);
            GameService.Instance.EnemyService.AddEnemy(clonedRobot);
        }
    }
}



