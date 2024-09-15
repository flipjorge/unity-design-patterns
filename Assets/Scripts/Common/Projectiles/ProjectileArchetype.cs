using UnityEngine;

[CreateAssetMenu(menuName = "Projectile Archetype")]
public class ProjectileArchetype : ScriptableObject
{
    public GameObject Prefab;
    public float Speed;
}
