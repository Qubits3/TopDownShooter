using UnityEngine;

namespace Characters
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class CharacterBase : MonoBehaviour
    {
        protected Rigidbody CharacterRigidbody { get; private set; }
        public float Health { get; private set; } = 100.0f;
        public float AttackPower { get; private set; } = 10.0f;

        protected float Speed { get; private set; } = 10.0f;
    
        protected void SetSpeed(float speed)
        {
            Speed = speed;
        }
        
        protected void SetAttackPower(float attackPower)
        {
            AttackPower = attackPower;
        }

        public void SetHealth(float health)
        {
            Health = health;
            Die();
        }

        protected virtual void Start()
        {
            CharacterRigidbody = GetComponent<Rigidbody>();
        }
        
        protected virtual void Update()
        {
            Move();
            
            Attack();
        }
    
        protected virtual void SpawnBullet()
        {
            if (!ObjectPooler.SharedInstance) return;

            var pooledObject = ObjectPooler.SharedInstance.GetPooledObject();
            pooledObject!.transform.position = transform.position;

            var bullet = pooledObject.GetComponent<Bullet>();
            bullet.SetOwner(this);

            pooledObject.SetActive(true);
        }

        protected abstract void Move();
    
        protected abstract void Attack();

        private void Die()
        {
            if (Health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}