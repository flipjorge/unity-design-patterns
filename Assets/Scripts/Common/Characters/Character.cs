using UnityEngine;

public class Character : MonoBehaviour, IStateMachineCharacter, IKillable
{
    [SerializeField] private CharacterController CharacterController;

    private const float Gravity = -9.8f;
    
    private float _currentGravitySpeed;
    private Vector3 _direction;
    
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

    public async Awaitable MoveTo(Vector3 position)
    {
        var direction = position - transform.position;
        direction = new Vector3(direction.x, 0, direction.z).normalized;
        var distance = Vector3.Distance(position, transform.position);
        
        while (distance > .2f)
        {
            Move(direction);
            
            distance = Vector3.Distance(position, transform.position);

            await Awaitable.NextFrameAsync();
        }
    }

    public async Awaitable Spin(int spins = 1)
    {
        float rotation = 0;
        float targetRotation = 360 * spins;

        while (rotation < targetRotation)
        {
            transform.Rotate(0, Speed, 0);
            rotation += Speed;

            await Awaitable.NextFrameAsync();
        }
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