using UnityEngine;

public class EnemyCharacterController : MonoBehaviour
{
    private StateMachine<ICharacter> _stateMachine;
    private ICharacter _character;
    private ICharacter _player;

    public void Initialize(ICharacter character, ICharacter player)
    {
        _character = character;
        _player = player;
    }

    private void Awake()
    {
        _stateMachine = new StateMachine<ICharacter>();
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
        var state = new CharacterWanderingState(_character, _player, StartFollwing);
        _stateMachine.ChangeTo(state);
    }
    
    private void StartFollwing()
    {
        var state =
            new CharacterFollowingState(_character, _player.Transform, StartWandering, Attack);
        _stateMachine.ChangeTo(state);
    }

    private void Attack()
    {
        var state = new CharacterAttackingState(_character, _player, StartFollwing);
        _stateMachine.ChangeTo(state);
    }
}