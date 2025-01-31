using StatePattern.StateMachine;
using UnityEngine;
using static UnityEditor.VersionControl.Asset;

namespace StatePattern.Enemy
{
    public class IdleState : IState
    {
        public EnemyController Owner { get; set; }
        private IStateMachine stateMachine;
        private float timer;

        public IdleState(IStateMachine stateMachine) => this.stateMachine = stateMachine;

        public void OnStateEnter() => ResetTimer();

        public void Update()
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                if (Owner.GetType() == typeof(OnePunchManController))
                    stateMachine.ChangeState(EnemyStates.ROTATING);
                else
                    stateMachine.ChangeState(EnemyStates.PATROLLING);
            }
        }

        public void OnStateExit() => timer = 0;

        private void ResetTimer() => timer = Owner.Data.IdleTime;
    }
}