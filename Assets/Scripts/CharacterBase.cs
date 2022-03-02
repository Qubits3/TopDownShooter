using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class CharacterBase : MonoBehaviour
{
    protected Rigidbody Rigidbody;
    protected float Speed { get; private set; } = 10.0f;
    
    protected void SetSpeed(float speed)
    {
        Speed = speed;
    }

    protected virtual void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    protected virtual void Update()
    {
        Move();
        
        Shoot();
    }

    /// <summary>
    /// This is got called in Update() so be careful using it.
    /// </summary>
    protected abstract void Move();

    /// <summary>
    /// This is got called in Update() so be careful using it.
    /// </summary>
    protected abstract void Shoot();
}