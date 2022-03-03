using UnityEngine;

namespace Characters
{
    public class EnemyBase : CharacterBase
    {
        private GameObject _player;
        protected Vector3 DistanceToPlayer;

        protected override void Start()
        {
            base.Start();
            
            _player = GameObject.FindWithTag("Player");
            SetSpeed(0.1f);
            SetAttackPower(5.0f);
            SetHealth(50);
        }

        protected override void Move()
        {
            if (!_player) return;
            
            DistanceToPlayer = _player.transform.position - transform.position;
            CharacterRigidbody.AddForce(DistanceToPlayer.normalized * Speed, ForceMode.Impulse);
        }

        protected override void Attack()
        {
            
        }
    }
}