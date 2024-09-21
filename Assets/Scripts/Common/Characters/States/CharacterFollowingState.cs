using System;
using UnityEngine;

public class CharacterFollowingState : State<ICharacter>
{
    private readonly Transform _target;
    private readonly Action _onPlayerLost;
    private readonly Action _onReachPlayer;

    private const float MaxRadius = 8;
    private const float DistanceThreshold = 2;

    public CharacterFollowingState(ICharacter owner, Transform target, Action onPlayerLost, Action onReachPlayer) : base(owner)
    {
        _target = target;
        _onPlayerLost = onPlayerLost;
        _onReachPlayer = onReachPlayer;
    }

    public override void Enter()
    {
        //
    }

    public override void Update()
    {
        var distance = Vector3.Distance(_target.position, Owner.CurrentPosition);

        if (distance > MaxRadius)
        {
            _onPlayerLost?.Invoke();
            
            return;
        }
        
        if (distance < DistanceThreshold)
        {
            _onReachPlayer?.Invoke();
            return;
        }

        var direction = _target.position - Owner.CurrentPosition;
        direction = new Vector3(direction.x, 0, direction.z);

        Owner.Move(direction.normalized);
    }

    public override void Exit()
    {
        //
    }
}