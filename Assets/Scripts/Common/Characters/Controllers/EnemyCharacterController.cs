using UnityEngine;

public class EnemyCharacterController : MonoBehaviour
{
    private StateMachine<IStateMachineCharacter> _stateMachine;
    private IStateMachineCharacter _character;
    private IStateMachineCharacter _player;

    public void Initialize(IStateMachineCharacter character, IStateMachineCharacter player)
    {
        _character = character;
        _player = player;
    }

    private void Awake()
    {
        _stateMachine = new StateMachine<IStateMachineCharacter>();
    }

    private void Start()
    {
        StartWandering();
    }

    private void Update()
    {
        _stateMachine.Update();
    }

    private void StartWandering()
    {
        var state = new CharacterWanderingState(_character, _player, StartFollowing);
        _stateMachine.ChangeTo(state);
    }
    
    private void StartFollowing()
    {
        var state =
            new CharacterFollowingState(_character, _player.Transform, StartWandering, Attack);
        _stateMachine.ChangeTo(state);
    }

    private void Attack()
    {
        var state = new CharacterAttackingState(_character, _player, StartFollowing);
        _stateMachine.ChangeTo(state);
    }
}