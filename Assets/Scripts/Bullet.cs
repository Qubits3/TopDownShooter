using Characters;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private CharacterBase _owner;

    private const float Speed = 10.0f;

    public void SetOwner(CharacterBase owner)
    {
        _owner = owner;
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _rigidbody.AddForce(_owner.transform.forward * Speed, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_owner == null) return;

        var enemy = other.gameObject;

        var hitsEnemy = enemy != _owner.gameObject;
        var characterBase = enemy.GetComponent<CharacterBase>();

        if (hitsEnemy && characterBase)
        {
            ApplyDamage(characterBase);
            gameObject.SetActive(false);
        }
    }

    private void ApplyDamage(CharacterBase enemy)
    {
        var health = enemy.Health - _owner.AttackPower;
        enemy.SetHealth(health);
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        if (!_rigidbody) return;

        SetOwner(null);
        _rigidbody.velocity = Vector3.zero;
    }
}