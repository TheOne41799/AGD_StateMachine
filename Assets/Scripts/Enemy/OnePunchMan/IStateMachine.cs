using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatePattern.StateMachine
{
    public interface IStateMachine
    {
        public void ChangeState(EnemyStates newState);
    }

    public enum EnemyStates
    {
        IDLE,
        ROTATING,
        SHOOTING,
        PATROLLING,
        CHASING
    }
}