using StatePattern.StateMachine;
using System.Collections.Generic;

namespace StatePattern.Enemy
{
    public class OnePunchManStateMachine : GenericStateMachine<OnePunchManController>
    {

        public OnePunchManStateMachine(OnePunchManController Owner) : base(Owner)
        {
            this.Owner = Owner;
            CreateStates();
            SetOwner();
        }

        private void CreateStates()
        {
            States.Add(StateMachine.EnemyStates.IDLE, new IdleState<OnePunchManController>(this));
            States.Add(StateMachine.EnemyStates.ROTATING, new RotatingState<OnePunchManController>(this));
            States.Add(StateMachine.EnemyStates.SHOOTING, new ShootingState<OnePunchManController>(this));
        }
    }
}