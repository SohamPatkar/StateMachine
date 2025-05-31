using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatePattern.Enemy
{
    public interface IStateMachine
    {
        void ChangeState(State state);
    }
}


