using UnityEngine;

public class BulletFactory
{
    public IProjectile Create(ProjectileArchetype archetype, Transform spawnPoint)
    {
        var instance = Object.Instantiate(archetype.Prefab, spawnPoint.position, spawnPoint.rotation);
        var projectile = instance.GetComponent<IProjectile>();
        projectile?.Initialize(archetype);
        projectile?.Fire();

        return projectile;
    }
}
