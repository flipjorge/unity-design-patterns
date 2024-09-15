using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BulletFactory
{
    private readonly Dictionary<ProjectileArchetype, ObjectPool<GameObject>> _pools = new();

    public IProjectile Create(ProjectileArchetype archetype, Transform spawnPoint)
    {
        var pool = GetPool(archetype);

        var instance = pool.Get();
        instance.transform.position = spawnPoint.position;
        instance.transform.rotation = spawnPoint.rotation;
        
        var projectile = instance.GetComponent<IProjectile>();
        projectile?.Initialize(archetype, () =>
        {
            pool.Release(instance);
        });
        
        projectile?.Fire();
        
        return projectile;
    }

    private ObjectPool<GameObject> GetPool(ProjectileArchetype archetype)
    {
        var pool = _pools.GetValueOrDefault(archetype);

        if (pool != null) return pool;
        
        pool = new ObjectPool<GameObject>(
            () => Object.Instantiate(archetype.Prefab),
            gameObject => gameObject.SetActive(true),
            gameObject => gameObject.SetActive(false),
            Object.Destroy);
            
        _pools.Add(archetype, pool);

        return pool;
    }
}
