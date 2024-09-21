using System.Diagnostics.Contracts;
using UnityEngine;

public class FactoryExample : MonoBehaviour
{
    [SerializeField] private CharacterArchetype[] EnemiesArchetypes;
    [SerializeField] private Transform SpawnPoint;
    [SerializeField] private float IntervalSeconds = 1;

    private CharacterFactory _characterFactory;
    private bool _keepSpawning;
    private int _currentArchetypeIndex;

    private void Awake()
    {
        _characterFactory = new CharacterFactory();
    }

    private void Start()
    {
        _ = StartSpawning();
    }

    private void OnDestroy()
    {
        StopSpawning();
    }

    private async Awaitable StartSpawning()
    {
        _keepSpawning = true;

        while (_keepSpawning)
        {
            var character = _characterFactory.Create(EnemiesArchetypes[_currentArchetypeIndex], SpawnPoint) as MonoBehaviour;
            
            if (character != null)
            {
                if (_currentArchetypeIndex == 0)
                {
                    var controller = character.gameObject.AddComponent<JustMoveForwardCharacterController>();
                    controller.Initialize(character as Character);
                }
                else
                {
                    var controller = character.gameObject.AddComponent<DrunkMoveForwardCharacterController>();
                    controller.Initialize(character as Character);
                }
            }
            
            _currentArchetypeIndex = (_currentArchetypeIndex + 1) % EnemiesArchetypes.Length;
            
            await Awaitable.WaitForSecondsAsync(IntervalSeconds);
        }
    }

    private void StopSpawning()
    {
        _keepSpawning = false;
    }
}