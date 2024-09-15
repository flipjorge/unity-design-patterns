using UnityEngine;

public class CanonBallProjectile : MonoBehaviour, IProjectile
{
    [SerializeField] private Rigidbody RigidBody;
    private float _speed;

    public void Initialize(ProjectileArchetype archetype)
    {
        _speed = archetype.Speed;
    }

    public void Fire()
    {
        RigidBody.AddForce(transform.forward * _speed, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }

    private void OnValidate()
    {
        RigidBody ??= GetComponent<Rigidbody>();
    }
}