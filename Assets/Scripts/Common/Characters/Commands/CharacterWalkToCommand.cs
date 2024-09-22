using UnityEngine;

public class CharacterWalkToCommand : ICommand
{
    private readonly Character _character;
    private readonly Vector3 _position;
    
    public CharacterWalkToCommand(Character character, Vector3 position)
    {
        _character = character;
        _position = position;
    }
    
    public async Awaitable Execute()
    {
        await _character.MoveTo(_position);
    }
}