using System;
using UnityEngine;

public class CharacterAttackingState : State<IStateMachineCharacter>
{
    private readonly IStateMachineCharacter _targetCharacter;
    private readonly Action _onFinishAttack;
    
    public CharacterAttackingState(IStateMachineCharacter owner, IStateMachineCharacter targetCharacter, Action onFinishAttack) : base(owner)
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
