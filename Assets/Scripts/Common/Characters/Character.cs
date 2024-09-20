using UnityEngine;

public class Character : MonoBehaviour, ICharacter, IKillable
{
    [SerializeField] private CharacterController CharacterController;

    private const float Gravity = -9.8f;

    private float _speed;
    private float _currentGravitySpeed;
    private Vector3 _direction;

    public void Initialize(CharacterArchetype archetype)
    {
        _speed = archetype.Speed;
    }
    
    private void Update()
    {
        var movement = _direction * (_speed * Time.deltaTime);

        if (CharacterController.isGrounded) _currentGravitySpeed = -1f;
        else _currentGravitySpeed += Gravity * Time.deltaTime;

        movement.y = _currentGravitySpeed * Time.deltaTime;

        CharacterController.Move(movement);
        
        _direction = Vector3.zero;
    }

    public void Move(Vector3 direction)
    {
        _direction = direction;
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
    
    private void OnValidate()
    {
        CharacterController ??= GetComponent<CharacterController>();
    }
}
