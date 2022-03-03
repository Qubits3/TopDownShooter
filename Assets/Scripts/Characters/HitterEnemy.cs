using System;
using UnityEngine;

namespace Characters
{
    public class HitterEnemy : EnemyBase
    {
        protected override void Start()
        {
            base.Start();
            
            SetAttackPower(100.0f);
            SetSpeed(0.2f);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                ApplyDamage(collision.gameObject.GetComponent<CharacterBase>());
            }
        }
    }
}
