using System;
using UnityEngine;

public class CanonBallProjectile : MonoBehaviour, IProjectile, IKillable
{
    [SerializeField] private Rigidbody RigidBody;
    private float _speed;
    private Action _onDestroy;
    private bool _isInUse;

    public void Initialize(ProjectileArchetype archetype, Action onDestroy = null)
    {
        _speed = archetype.Speed;
        _onDestroy = onDestroy;

        _isInUse = true;
    }

    public void Fire()
    {
        RigidBody.AddForce(transform.forward * _speed, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision other)
    {
        Kill();
    }
    
    public void Kill()
    {
        _isInUse = false;
        RigidBody.angularVelocity = Vector3.zero;
        RigidBody.linearVelocity = Vector3.zero;
        
        _onDestroy?.Invoke();
    }
    
    private void OnDestroy()
    {
        if (!_isInUse) return;
        
        _onDestroy?.Invoke();
    }
    
    private void OnValidate()
    {
        RigidBody ??= GetComponent<Rigidbody>();
    }
}