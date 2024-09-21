using System;
using UnityEngine;

public class CharacterAttackingState : State<ICharacter>
{
    private readonly ICharacter _targetCharacter;
    private readonly Action _onFinishAttack;
    
    public CharacterAttackingState(ICharacter owner, ICharacter targetCharacter, Action onFinishAttack) : base(owner)
    {
        _targetCharacter = targetCharacter;
        _onFinishAttack = onFinishAttack;
    }

    public override async void Enter()
    {
        _targetCharacter.ReceiveDamage(Owner.Damage);
        
        await Awaitable.WaitForSecondsAsync(1);
        
        _onFinishAttack?.Invoke();
    }

    public override void Update()
    {
        //
    }

    public override void Exit()
    {
        //
    }
}
