using UnityEngine;

public class DrunkMoveForwardCharacterController : MonoBehaviour
{
    [SerializeField] private Character Character;

    private float _initialTime;

    private void Awake()
    {
        _initialTime = Time.time;
    }

    private void Update()
    {
        var direction = transform.forward;
        direction += transform.right * (Mathf.Sin((Time.time - _initialTime) + 1.5f));

        Character.Move(direction.normalized);
    }

    private void OnValidate()
    {
        Character ??= GetComponent<Character>();
    }
}