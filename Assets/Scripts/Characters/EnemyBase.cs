using UnityEngine;

namespace Characters
{
    public class EnemyBase : CharacterBase
    {
        private GameObject _player;
        private Vector3 _distanceToPlayer;

        protected override void Start()
        {
            _player = GameObject.FindWithTag("Player");
            SetSpeed(0.1f);
            SetAttackPower(5.0f);
            SetHealth(50);

            base.Start();
        }

        protected override void Move()
        {
            _distanceToPlayer = _player.transform.position - transform.position;
            CharacterRigidbody.AddForce(_distanceToPlayer.normalized * Speed, ForceMode.Impulse);
        }

        protected override void Attack()
        {
            if (_distanceToPlayer.magnitude <= 10.0f)
            {
                SpawnBullet();
            }
        }
    }
}