using System;
using UnityEngine;

public class ObjectPoolExample : MonoBehaviour
{
    [SerializeField] private RotatingTurretGun Gun;

    private BulletFactory _bulletFactory;
    
    private void Awake()
    {
        _bulletFactory = new BulletFactory();
        Gun.Initialize(_bulletFactory);
    }

    private void Start()
    {
        _ = Gun.StartFiring();
    }

    private void OnDestroy()
    {
        Gun.StopFiring();
    }
}
