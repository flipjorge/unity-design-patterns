using System;
using UnityEngine;

public class FactoryExample : MonoBehaviour
{
    [SerializeField] private EnemyArchetype EnemyArchetype;
    [SerializeField] private float IntervalSeconds = 1;
    [SerializeField] private Transform SpawnPoint;
    
    private EnemyFactory _enemyFactory;
    private bool _keepSpawning;
    
    private void Awake()
    {
        _enemyFactory = new EnemyFactory();
    }

    private void Start()
    {
        StartSpawning();
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
            _enemyFactory.Create(EnemyArchetype, SpawnPoint);

            await Awaitable.WaitForSecondsAsync(IntervalSeconds);
        }
    }

    private void StopSpawning()
    {
        _keepSpawning = false;
    }
}
