using UnityEngine;

public class CommandExample : MonoBehaviour
{
    [SerializeField] private CharacterArchetype PlayerArchetype;
    [SerializeField] private Transform PlayerSpawnPoint;
    
    private CharacterFactory _characterFactory;
    
    private void Awake()
    {
        _characterFactory = new CharacterFactory();
    }

    private void Start()
    {
        var playerCharacter = _characterFactory.Create(PlayerArchetype, PlayerSpawnPoint);
        if (playerCharacter == null) return;

        var playerController = playerCharacter.gameObject.AddComponent<CommandCharacterController>();
        playerController.Initialize(playerCharacter);
    }
}
