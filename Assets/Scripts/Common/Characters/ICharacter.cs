using UnityEngine;

public interface ICharacter
{
    void Initialize(CharacterArchetype archetype);
    void Move(Vector3 direction);
}