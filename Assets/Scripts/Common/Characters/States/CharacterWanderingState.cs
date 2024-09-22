using System;
using System.Threading;
using UnityEngine;
using Random = UnityEngine.Random;

public class CharacterWanderingState : State<IStateMachineCharacter>
{
    private readonly IStateMachineCharacter _player;
    private readonly Action _onPlayerDetected;
    private readonly CancellationTokenSource _cancellationToken;

    private bool _isWandering;
    private Vector3 _targetPosition;

    private const float MaxRadius = 1;
    private const float DistanceThreshold = .1f;
    private const float RestTime = 2f;
    private const float DetectingDistance = 5;

    public CharacterWanderingState(IStateMachineCharacter owner, IStateMachineCharacter player, Action onPlayerDetected) : base(owner)
    {
        _player = player;
        _onPlayerDetected = onPlayerDetected;

        _cancellationToken = new CancellationTokenSource();
    }

    public override void Enter()
    {
        StartWandering();
    }

    public override void Update()
    {
        var distanceToPlayer = Vector3.Distance(_player.Transform.position, Owner.Transform.position);
        if (distanceToPlayer > DetectingDistance) return;

        _isWandering = false;
        _cancellationToken.Cancel();
        _onPlayerDetected?.Invoke();
    }

    public override void Exit()
    {
        _isWandering = false;
    }

    private async void StartWandering()
    {
        _isWandering = true;

        try
        {
            while (_isWandering)
            {
                _targetPosition = GetNextPosition();

                await MovingToNextPosition();

                await Awaitable.WaitForSecondsAsync(RestTime, _cancellationToken.Token);
            }
        }
        catch (OperationCanceledException)
        {
            //
        }
    }

    private async Awaitable MovingToNextPosition()
    {
        try
        {
            var distance = Vector3.Distance(_targetPosition, Owner.Transform.position);

            while (distance > DistanceThreshold)
            {
                var direction = _targetPosition - Owner.Transform.position;
                direction = new Vector3(direction.x, 0, direction.z);

                Owner.Move(direction.normalized);

                distance = Vector3.Distance(_targetPosition, Owner.Transform.position);
                await Awaitable.NextFrameAsync(_cancellationToken.Token);
            }
        }
        catch (OperationCanceledException)
        {
            //
        }
    }

    private Vector3 GetNextPosition()
    {
        var positionX = Random.Range(-MaxRadius, MaxRadius);
        var positionZ = Random.Range(-MaxRadius, MaxRadius);

        return Owner.Transform.position + new Vector3(positionX, 0, positionZ);
    }
}