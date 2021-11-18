using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CountEnemy : MonoBehaviour
{
    private Room[,] rooms;
    private int enemyCount = 0;
    private int x, z;
    private bool isTimeToSpawn = true;

    [SerializeField] private int minEnemys, maxEnemys;


    public void SpawnedRooms(Room[,] spawnedRooms)
    {
        rooms = spawnedRooms;
    }

    public void EnemyDeath()
    {
        enemyCount--;
        if (enemyCount <= 0)
        {
            rooms[x, z].OpenRoom();
        }
    }

    public void IncreaseMinMax(int i, int j)
    {
        x = i;
        z = j;
        int newEnemies = Random.Range(minEnemys / 2, (maxEnemys + 1) / 2);
        enemyCount += newEnemies;
        rooms[x, z].SpawnEnemiesWithMinMax(newEnemies);
        minEnemys++;
        maxEnemys += 2;
    }

    public void EnemyDoSpawn()
    {
        if (isTimeToSpawn)
        {
            isTimeToSpawn = false;
            StartCoroutine(TimeToSpawnTimer());
            int newEnemies = Random.Range(minEnemys, (maxEnemys + 1));
            enemyCount += newEnemies;
            rooms[x, z].EnemyDoSpawn(newEnemies);
        }
    }

    private IEnumerator TimeToSpawnTimer()
    {
        yield return new WaitForSeconds(10);
        isTimeToSpawn = true;
    }
}


