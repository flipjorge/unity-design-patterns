using UnityEngine;

public class EnemyFactory
{
    public IEnemy Create(EnemyArchetype archetype, Transform spawnPoint)
    {
        var instance = Object.Instantiate(archetype.Prefab, spawnPoint.position, spawnPoint.rotation);
        var enemy = instance.GetComponent<IEnemy>();
        enemy?.Initialize(archetype.Speed);

        return enemy;
    }
}