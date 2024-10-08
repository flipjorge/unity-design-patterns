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
        var playerCharacter = _characterFactory.Create(PlayerArchetype, PlayerSpawnPoint);
        if (playerCharacter == null) return;
        
        _playerController = playerCharacter.gameObject.AddComponent<PlayerCharacterController>();
        _playerController.Initialize(playerCharacter, MoveAction.action);

        var enemyCharacter = _characterFactory.Create(EnemyArchetype, EnemySpawnPoint);
        if (enemyCharacter == null) return;
        
        _enemyController = enemyCharacter.gameObject.AddComponent<EnemyCharacterController>();
        _enemyController.Initialize(enemyCharacter, playerCharacter);
    }

    private void Update()
    {
        _playerController.Update();
    }
}