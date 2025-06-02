using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatePattern.Enemy
{
    public interface IState
    {
        public EnemyController Owner { get; set; }

        public void OnEnterState();
        public void UpdateState();
        public void OnExitState();
    }


}


