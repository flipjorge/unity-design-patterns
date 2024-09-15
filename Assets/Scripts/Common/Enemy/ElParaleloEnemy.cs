using UnityEngine;

public class ElParaleloEnemy : MonoBehaviour, IEnemy, IKillable
{
    [SerializeField] private CharacterController CharacterController;

    private const float Gravity = -9.8f;

    private float _speed;
    private float _currentGravitySpeed;
    private float _initialTime;

    public void Initialize(EnemyArchetype archetype)
    {
        _speed = archetype.Speed;
        _initialTime = Time.time;
    }

    private void Update()
    {
        var moveDirection = transform.forward * (_speed * Time.deltaTime);
        moveDirection += transform.right * (Mathf.Sin((Time.time - _initialTime) * 3 + 1.5f) * 3f * Time.deltaTime);

        if (CharacterController.isGrounded) _currentGravitySpeed = -1f;
        else _currentGravitySpeed += Gravity * Time.deltaTime;

        moveDirection.y = _currentGravitySpeed * Time.deltaTime;

        CharacterController.Move(moveDirection);
    }

    private void OnValidate()
    {
        CharacterController ??= GetComponent<CharacterController>();
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
}