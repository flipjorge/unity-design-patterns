using UnityEngine;
using UnityEngine.InputSystem;

public class StateMachineExample : MonoBehaviour
{
    [SerializeField] private CharacterArchetype PlayerArchetype;
    [SerializeField] private CharacterArchetype EnemyArchetype;
    [SerializeField] private Transform PlayerSpawnPoint;
    [SerializeField] private Transform EnemySpawnPoint;
    [SerializeField] private InputActionReference MoveAction;
    
    private CharacterFactory _characterFactory;
    private PlayerCharacterController _playerController;

    private EnemyCharacterController _enemyController;

    private void Awake()
    {
        _characterFactory = new CharacterFactory();
    }

    private void Start()
    {
        var playerCharacter = _characterFactory.Create(PlayerArchetype, PlayerSpawnPoint) as MonoBehaviour;
        if (playerCharacter == null) return;
        
        _playerController = playerCharacter.gameObject.AddComponent<PlayerCharacterController>();
        _playerController.Initialize(playerCharacter as IStateMachineCharacter, MoveAction.action);

        var enemyCharacter = _characterFactory.Create(EnemyArchetype, EnemySpawnPoint) as MonoBehaviour;
        if (enemyCharacter == null) return;
        
        _enemyController = enemyCharacter.gameObject.AddComponent<EnemyCharacterController>();
        _enemyController.Initialize(enemyCharacter as IStateMachineCharacter, playerCharacter as IStateMachineCharacter);
    }

    private void Update()
    {
        _playerController.Update();
    }
}