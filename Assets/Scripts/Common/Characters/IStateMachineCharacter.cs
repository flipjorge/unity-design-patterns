using UnityEngine;

public interface IStateMachineCharacter
{
    Transform Transform { get; }
    int Damage { get; }
    
    void Move(Vector3 direction);
    void ReceiveDamage(int damage);
}