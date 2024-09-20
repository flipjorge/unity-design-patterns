using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCharacterController : MonoBehaviour
{
    [SerializeField] private Character Character;
    [SerializeField] private CharacterArchetype Archetype;

    private InputAction _moveAction;

    private void Awake()
    {
        Character.Initialize(Archetype);
        _moveAction = InputSystem.actions.FindAction("Player/Move");
    }

    private void Update()
    {
        if (_moveAction.IsPressed())
        {
            var inputDirection = _moveAction.ReadValue<Vector2>();
            var moveDirection = new Vector3(inputDirection.x, 0, inputDirection.y);

            Character.Move(moveDirection);
        }
    }
}