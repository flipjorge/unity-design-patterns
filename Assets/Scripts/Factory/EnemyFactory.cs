using UnityEngine;

public class EnemyFactory
{
    public ICharacter Create(CharacterArchetype archetype, Transform spawnPoint)
    {
        var instance = Object.Instantiate(archetype.Prefab, spawnPoint.position, spawnPoint.rotation);
        var enemy = instance.GetComponent<ICharacter>();
        enemy?.Initialize(archetype);

        return enemy;
    }
}