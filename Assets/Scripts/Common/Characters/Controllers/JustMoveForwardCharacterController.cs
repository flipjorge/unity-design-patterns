using UnityEngine;

public class JustMoveForwardCharacterController : MonoBehaviour
{
    [SerializeField] private Character Character;

    private void Update()
    {
        Character.Move(transform.forward);
    }

    private void OnValidate()
    {
        Character ??= GetComponent<Character>();
    }
}