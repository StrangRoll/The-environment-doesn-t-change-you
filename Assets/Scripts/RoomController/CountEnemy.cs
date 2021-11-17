using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CountEnemy : MonoBehaviour
{
    private Room[,] rooms;
    private int enemyCount = 0;
    private int x, z;

    [SerializeField] private int minEnemys, maxEnemys;

    public void SpawnedRooms(Room[,] spawnedRooms)
    {
        rooms = spawnedRooms;
    }

    public void NewEnemies(int count, int i, int j)
    {
        enemyCount = count;
        x = i;
        z = j;
    }

    public void EnemyDeath()
    {
        enemyCount--;
        if (enemyCount <= 0)
        {
            rooms[x, z].OpenRoom();
        }
    }

    public void IncreaseMinMax(int x, int z)
    {
        rooms[x, z].SpawnEnemiesWithMinMax(minEnemys, maxEnemys);
        minEnemys++;
        maxEnemys++;
    }
}


