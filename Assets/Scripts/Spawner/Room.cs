using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Room : MonoBehaviour
{
    [SerializeField] private Spawner spawner;
    [SerializeField] private EnemyLIfe[] enemyPrefab;

    private int countEnemies;
    [SerializeField] private SendEvent MinMaxEvent;
    private float x, z;
    private int xE, zE;
    private int roomCount;
    private Room[,] spawnedRooms;

    void Start()
    {
        x = transform.position.x;
        z = transform.position.z;

        xE = (int)Mathf.Round(transform.position.x / spawner.roomSize);
        zE = (int)Mathf.Round(transform.position.z / spawner.roomSize);

        roomCount = spawner.roomCount;
        spawnedRooms = spawner.spawnedRooms;
        if (transform.position.y < -50) return;
        if (xE > 0)
            if (spawnedRooms[xE - 1, zE] != null)
            {
                transform.GetChild(0).gameObject.SetActive(false);
                transform.GetChild(4).gameObject.SetActive(true);
            }

        if (xE < roomCount - 1)
            if (spawnedRooms[xE + 1, zE] != null)
            {
                transform.GetChild(1).gameObject.SetActive(false);
                transform.GetChild(5).gameObject.SetActive(true);
            }

        if (zE < roomCount - 1)
            if (spawner.spawnedRooms[xE, zE + 1] != null)
            {
                transform.GetChild(2).gameObject.SetActive(false);
                transform.GetChild(6).gameObject.SetActive(true);
            }

        if (zE > 0)
            if (spawnedRooms[xE, zE - 1] != null)
            {
                transform.GetChild(3).gameObject.SetActive(false);
                transform.GetChild(7).gameObject.SetActive(true);
            }
    }
    public void OpenRoom()
    {
        if (transform.position.y < -50) return;
        if (xE > 0)
            if (spawnedRooms[xE - 1, zE] != null)
            {
                transform.GetChild(0).gameObject.SetActive(false);
            }
                
        if (xE < roomCount - 1)
            if (spawner.spawnedRooms[xE + 1, zE] != null)
            {
                transform.GetChild(1).gameObject.SetActive(false);
            }

        if (zE < roomCount - 1)
            if (spawnedRooms[xE, zE + 1] != null)
            {
                transform.GetChild(2).gameObject.SetActive(false);
            }

        if (zE > 0)
            if (spawnedRooms[xE, zE - 1] != null)
            {
                transform.GetChild(3).gameObject.SetActive(false);
            }
    }

    public void CloseRoom()
    {
        if (transform.position.y < -50) return;
        if (xE > 0)
            if (spawnedRooms[xE - 1, zE] != null)
            {
                transform.GetChild(0).gameObject.SetActive(true);
                transform.GetChild(4).gameObject.SetActive(false);
            }

        if (xE < roomCount - 1)
            if (spawnedRooms[xE + 1, zE] != null)
            {
                transform.GetChild(1).gameObject.SetActive(true);
                transform.GetChild(5).gameObject.SetActive(false);
            }

        if (zE < roomCount - 1)
            if (spawnedRooms[xE, zE + 1] != null)
            {
                transform.GetChild(2).gameObject.SetActive(true);
                transform.GetChild(6).gameObject.SetActive(false);
            }

        if (zE > 0)
            if (spawnedRooms[xE, zE - 1] != null)
            {
                transform.GetChild(3).gameObject.SetActive(true);
                transform.GetChild(7).gameObject.SetActive(false);
            }
        transform.GetChild(8).gameObject.SetActive(true);

        StartCoroutine(SpawnEnemies());

    }

    private IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds(10);
        MinMaxEvent?.Invoke(xE, zE);
    }
    public void SpawnEnemiesWithMinMax(int enemyCount)
    {
        for (int i = 0; i < enemyCount; i++)
        {
            int index = Random.Range(0, enemyPrefab.Length);
            Instantiate(enemyPrefab[index], new Vector3(Random.Range(x, x + 10), 8, Random.Range(z - 10, z)), Quaternion.identity);
        }
    }
    public void EnemyDoSpawn(int enemyCount)
    {
        transform.GetChild(8).gameObject.SetActive(false);
        transform.GetChild(8).gameObject.SetActive(true);
        StartCoroutine(WhaitingAndSpawn(enemyCount));
    }
    private IEnumerator WhaitingAndSpawn(int enemyCount)
    {
        yield return new WaitForSeconds(10);
        for (int i = 0; i < enemyCount; i++)
        {
            int index = Random.Range(0, enemyPrefab.Length);
            Instantiate(enemyPrefab[index], new Vector3(Random.Range(x, x + 10), 8, Random.Range(z - 10, z)), Quaternion.identity);
        }
    }

}

[System.Serializable]
public class SendEvent : UnityEvent<int, int> { }




