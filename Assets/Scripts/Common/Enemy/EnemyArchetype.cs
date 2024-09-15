using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Archetype")]
public class EnemyArchetype : ScriptableObject
{
    public GameObject Prefab;
    public float Speed;
}
