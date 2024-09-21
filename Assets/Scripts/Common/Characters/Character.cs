using UnityEngine;

public class Character : MonoBehaviour, ICharacter, IKillable
{
    [SerializeField] private CharacterController CharacterController;

    private const float Gravity = -9.8f;
    
    private float _currentGravitySpeed;
    private Vector3 _direction;

    public Vector3 CurrentPosition => transform.position;
    public Transform Transform => transform;
    public float Speed { get; private set; }
    public int Damage { get; private set; }

    public void Initialize(CharacterArchetype archetype)
    {
        Speed = archetype.Speed;
        Damage = archetype.Damage;
    }

    private void Update()
    {
        var movement = _direction * (Speed * Time.deltaTime);

        if (CharacterController.isGrounded) _currentGravitySpeed = -1f;
        else _currentGravitySpeed += Gravity * Time.deltaTime;

        movement.y = _currentGravitySpeed * Time.deltaTime;

        CharacterController.Move(movement);

        if (_direction.sqrMagnitude > 0)
            transform.rotation = Quaternion.LookRotation(_direction);

        _direction = Vector3.zero;
    }

    public void Move(Vector3 direction)
    {
        _direction = direction;
    }

    public void ReceiveDamage(int damage)
    {
        Debug.Log($"Suffered damage: {damage}");
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