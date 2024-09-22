using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCharacterController : MonoBehaviour
{
    private IStateMachineCharacter _character;
    private InputAction _moveAction;

    public void Initialize(IStateMachineCharacter character, InputAction moveAction)
    {
        _character = character;
        _moveAction = moveAction;
    }

    public void Update()
    {
        if (!_moveAction.IsPressed()) return;

        var inputDirection = _moveAction.ReadValue<Vector2>();
        var moveDirection = new Vector3(inputDirection.x, 0, inputDirection.y);

        _character.Move(moveDirection);
    }
}