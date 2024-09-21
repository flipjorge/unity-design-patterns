using UnityEngine;

public interface ICharacter
{
    Vector3 CurrentPosition { get; }
    Transform Transform { get; }
    float Speed { get; }
    int Damage { get; }

    void Initialize(CharacterArchetype archetype);
    void Move(Vector3 direction);
    void ReceiveDamage(int damage);
}