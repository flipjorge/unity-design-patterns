using UnityEngine;

public class JustMoveForwardCharacterController : MonoBehaviour
{
    private Character _character;

    public void Initialize(Character character)
    {
        _character = character;
    }

    private void Update()
    {
        _character.Move(_character.transform.forward);
    }
}