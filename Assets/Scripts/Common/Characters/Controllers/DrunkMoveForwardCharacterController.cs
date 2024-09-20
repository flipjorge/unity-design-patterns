using UnityEngine;

public class DrunkMoveForwardCharacterController : MonoBehaviour
{
    private Character _character;

    private float _initialTime;

    public void Initialize(Character character)
    {
        _character = character;
    }
    
    private void Awake()
    {
        _initialTime = Time.time;
    }

    private void Update()
    {
        var direction = transform.forward;
        direction += transform.right * (Mathf.Sin((Time.time - _initialTime) + 1.5f));

        _character.Move(direction.normalized);
    }

    private void OnValidate()
    {
        _character ??= GetComponent<Character>();
    }
}