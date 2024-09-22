using UnityEngine;

public class CharacterFactory
{
    public Character Create(CharacterArchetype archetype, Transform spawnPoint)
    {
        var instance = Object.Instantiate(archetype.Prefab, spawnPoint.position, spawnPoint.rotation);
        var enemy = instance.GetComponent<Character>();
        enemy?.Initialize(archetype);

        return enemy;
    }
}