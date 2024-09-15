using System;

public interface IProjectile
{
    public void Initialize(ProjectileArchetype archetype, Action onDestroy);
    public void Fire();
}