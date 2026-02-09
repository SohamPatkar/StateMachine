using StatePattern.Player;
using StatePattern.Main;
using UnityEngine;

namespace StatePattern.Enemy
{
    public class ShootingState<T> : IState where T : EnemyController
    {
        public EnemyController Owner { get; set; }
        private GenericStateMachine<T> stateMachine;
        private PlayerController target;
        private float timer;
        private float shootTimer;

        public ShootingState(GenericStateMachine<T> stateMachine) => this.stateMachine = stateMachine;

        public void OnEnterState()
        {
            SetTarget();
            shootTimer = 0;
        }

        public void UpdateState()
        {
            Quaternion desiredRotation = CalculateRotationTowardsPlayer();
            Owner.SetRotation(RotateTowards(desiredRotation));

            if (IsRotationComplete(desiredRotation))
            {
                shootTimer -= Time.deltaTime;
                if (shootTimer <= 0)
                {
                    ResetTimer();
                    Owner.Shoot();
                }
            }
        }

        private void SetTarget() => target = GameService.Instance.PlayerService.GetPlayer();

        private Quaternion CalculateRotationTowardsPlayer()
        {
            Vector3 directionToPlayer = target.Position - Owner.Position;
            directionToPlayer.y = 0f;
            return Quaternion.LookRotation(directionToPlayer, Vector3.up);
        }

        public void OnExitState() => target = null;

        private Quaternion RotateTowards(Quaternion desiredRotation) => Quaternion.LerpUnclamped(Owner.Rotation, desiredRotation, Owner.Data.RotationSpeed / 30 * Time.deltaTime);

        private bool IsRotationComplete(Quaternion desiredRotation) => Quaternion.Angle(Owner.Rotation, desiredRotation) < Owner.Data.RotationThreshold;

        private void ResetTimer() => shootTimer = Owner.Data.RateOfFire;
    }
}
