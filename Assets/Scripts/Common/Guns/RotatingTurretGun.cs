using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class RotatingTurretGun : MonoBehaviour
{
    [SerializeField] private Transform SpawnPointLeft;
    [SerializeField] private Transform SpawnPointRight;
    [SerializeField] private ProjectileArchetype LeftProjectileArchetype;
    [SerializeField] private ProjectileArchetype RightProjectileArchetype;
    [SerializeField] private float RotatingSpeed = 0;
    [SerializeField] private float FireRate = .1f;

    private BulletFactory _bulletFactory;
    private bool _isActive;

    public void Initialize(BulletFactory factory)
    {
        _bulletFactory = factory;
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0, RotatingSpeed, 0));
    }

    private void OnDestroy()
    {
        StopFiring();
    }

    public async Awaitable StartFiring()
    {
        if (_isActive) return;

        _isActive = true;

        while (_isActive)
        {
            Fire();

            await Awaitable.WaitForSecondsAsync(1 / FireRate);
        }
    }

    public void StopFiring()
    {
        _isActive = false;
    }

    private void Fire()
    {
        _bulletFactory.Create(LeftProjectileArchetype, SpawnPointLeft);
        _bulletFactory.Create(RightProjectileArchetype, SpawnPointRight);
    }
}