using StatePattern.StateMachine;
using System.Collections.Generic;

namespace StatePattern.Enemy
{
    public class OnePunchManStateMachine : IStateMachine
    {
        private OnePunchManController Owner;
        private IState currentState;
        protected Dictionary<EnemyStates, IState> States = new Dictionary<EnemyStates, IState>();

        public OnePunchManStateMachine(OnePunchManController Owner)
        {
            this.Owner = Owner;
            CreateStates();
            SetOwner();
        }

        private void CreateStates()
        {
            States.Add(StateMachine.EnemyStates.IDLE, new IdleState(this));
            States.Add(StateMachine.EnemyStates.ROTATING, new RotatingState(this));
            States.Add(StateMachine.EnemyStates.SHOOTING, new ShootingState(this));
        }

        private void SetOwner()
        {
            foreach (IState state in States.Values)
            {
                state.Owner = Owner;
            }
        }

        public void Update() => currentState?.Update();

        protected void ChangeState(IState newState)
        {
            currentState?.OnStateExit();
            currentState = newState;
            currentState?.OnStateEnter();
        }

        public void ChangeState(EnemyStates newState) => ChangeState(States[newState]);
    }
}