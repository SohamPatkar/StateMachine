using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatePattern.Enemy
{
    public interface IStateMachine
    {
        public void ChangeState(State state);
    }
}


