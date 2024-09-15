using UnityEngine;

public class CapsuleEnemy : MonoBehaviour, IEnemy, IKillable
{
    [SerializeField] private CharacterController CharacterController;

    private const float Gravity = -9.8f;
    
    private float _speed;
    private float _currentGravitySpeed;

    public void Initialize(float speed)
    {
        _speed = speed;
    }

    private void Update()
    {
        Vector3 moveDirection = transform.forward * (_speed * Time.deltaTime);
        
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