using UnityEngine;

[CreateAssetMenu(menuName = "Character Archetype")]
public class CharacterArchetype : ScriptableObject
{
    public GameObject Prefab;
    public float Speed;
    public int Damage;
}
