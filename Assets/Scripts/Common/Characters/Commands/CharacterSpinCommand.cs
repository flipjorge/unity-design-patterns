using UnityEngine;

public class CharacterSpinCommand : ICommand
{
    private readonly Character _character;
    private readonly int _spins;
    
    public CharacterSpinCommand(Character character, int spins = 1)
    {
        _character = character;
        _spins = spins;
    }
    
    public async Awaitable Execute()
    {
        await _character.Spin(_spins);
    }
}
