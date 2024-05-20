using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemyPrefab; // The enemy prefab to be instantiated
    public float spawnInterval = 1f; // Time interval between spawns in seconds
    public int numberOfEnemies = 5;
    private Room currentRoom;

    void Start()
    {
        currentRoom = GetComponentInParent<Room>(); // Assuming the spawner is a child of the room prefab
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            enemy.GetComponent<Enemy>().OnEnemyDeath += EnemyKilled;
            currentRoom.enemyCount++;
        }
    }

    void EnemyKilled()
    {
        currentRoom.EnemyKilled();
    }
}
