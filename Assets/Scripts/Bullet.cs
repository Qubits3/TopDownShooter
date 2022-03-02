using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private const float Speed = 10.0f;
    private CharacterBase _owner;

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
        _rigidbody.AddRelativeForce(_owner.transform.forward * Speed, ForceMode.Impulse);
    }

    private void OnDisable()
    {
        if (!_rigidbody) return;
        
        SetOwner(null);
        _rigidbody.velocity = Vector3.zero;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_owner == null) return;

        if (collision.collider.gameObject != _owner.gameObject)
        {
            // Apply damage and disable
            gameObject.SetActive(false);
        }
    }
}