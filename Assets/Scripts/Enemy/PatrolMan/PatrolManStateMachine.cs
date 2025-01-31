using StatePattern.StateMachine;
using System.Collections.Generic;
using UnityEngine;

namespace StatePattern.Enemy
{
    public class PatrolManStateMachine : GenericStateMachine<PatrolManController>
    {
        public PatrolManStateMachine(PatrolManController Owner) : base(Owner)
        {
            this.Owner = Owner;
            CreateStates();
            SetOwner();
        }

        private void CreateStates()
        {
            States.Add(StateMachine.EnemyStates.IDLE, new IdleState<PatrolManController>(this));
            States.Add(StateMachine.EnemyStates.PATROLLING, new PatrollingState<PatrolManController>(this));
            States.Add(StateMachine.EnemyStates.CHASING, new ChasingState<PatrolManController>(this));
            States.Add(StateMachine.EnemyStates.SHOOTING, new ShootingState<PatrolManController>(this));
        }
    }
}