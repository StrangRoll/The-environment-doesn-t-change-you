using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountEnemy : MonoBehaviour
{
    private Room[,] rooms;
    private int enemyCount = 0;
    private int x, z;

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
}
