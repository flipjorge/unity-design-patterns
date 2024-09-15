using UnityEngine;

public class FactoryExample : MonoBehaviour
{
    [SerializeField] private EnemyArchetype[] EnemiesArchetypes;
    [SerializeField] private Transform SpawnPoint;
    [SerializeField] private float IntervalSeconds = 1;

    private EnemyFactory _enemyFactory;
    private bool _keepSpawning;
    private int _currentArchetypeIndex;

    private void Awake()
    {
        _enemyFactory = new EnemyFactory();
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
            _enemyFactory.Create(EnemiesArchetypes[_currentArchetypeIndex], SpawnPoint);
            _currentArchetypeIndex = (_currentArchetypeIndex + 1) % EnemiesArchetypes.Length;
            
            await Awaitable.WaitForSecondsAsync(IntervalSeconds);
        }
    }

    private void StopSpawning()
    {
        _keepSpawning = false;
    }
}