using UnityEngine;

public class CommandCharacterController : MonoBehaviour
{
    private Character _character;
    private CommandManager _commandManager;

    public void Initialize(Character character)
    {
        _character = character;
    }

    private void Awake()
    {
        _commandManager = new CommandManager();
    }

    private void Start()
    {
        _commandManager.ExecuteCommand(new CharacterSpinCommand(_character, 5));
        _commandManager.ExecuteCommand(new CharacterWalkToCommand(_character, new Vector3(-9, 0, 5)));
        _commandManager.ExecuteCommand(new CharacterSpinCommand(_character,2));
        _commandManager.ExecuteCommand(new CharacterWalkToCommand(_character, new Vector3(15, 0, 4)));
        _commandManager.ExecuteCommand(new CharacterSpinCommand(_character,3));
        _commandManager.ExecuteCommand(new CharacterWalkToCommand(_character, new Vector3(2, 0, 20)));
        _commandManager.ExecuteCommand(new CharacterSpinCommand(_character,10));
    }
}