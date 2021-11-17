using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Room : MonoBehaviour
{
    [SerializeField] private Spawner spawner;
    [SerializeField] private EnemyLIfe[] enemyPrefab;

    private int countEnemies;
    [SerializeField] private SendCountEnemyEvent SendEnemyCount;
    [SerializeField] private SendEvent MinMaxEvent;

    void Start()
    {
        int x = (int)Mathf.Round(transform.position.x / spawner.roomSize);
        int z = (int)Mathf.Round(transform.position.z / spawner.roomSize);
        if (transform.position.y < -50) return;
        if (x > 0)
            if (spawner.spawnedRooms[x - 1, z] != null)
            {
                transform.GetChild(0).gameObject.SetActive(false);
                transform.GetChild(4).gameObject.SetActive(true);
            }

        if (x < spawner.roomCount - 1)
            if (spawner.spawnedRooms[x + 1, z] != null)
            {
                transform.GetChild(1).gameObject.SetActive(false);
                transform.GetChild(5).gameObject.SetActive(true);
            }

        if (z < spawner.roomCount - 1)
            if (spawner.spawnedRooms[x, z + 1] != null)
            {
                transform.GetChild(2).gameObject.SetActive(false);
                transform.GetChild(6).gameObject.SetActive(true);
            }

        if (z > 0)
            if (spawner.spawnedRooms[x, z - 1] != null)
            {
                transform.GetChild(3).gameObject.SetActive(false);
                transform.GetChild(7).gameObject.SetActive(true);
            }
    }
    public void OpenRoom()
    {
        //Debug.Log(Mathf.Round(transform.position.x / spawner.roomSize) - 1);
        int x = (int)Mathf.Round(transform.position.x / spawner.roomSize);
        int z = (int)Mathf.Round(transform.position.z / spawner.roomSize);
        if (transform.position.y < -50) return;
        if (x > 0)
            if (spawner.spawnedRooms[x - 1, z] != null)
            {
                transform.GetChild(0).gameObject.SetActive(false);
            }
                
        if (x < spawner.roomCount - 1)
            if (spawner.spawnedRooms[x + 1, z] != null)
            {
                transform.GetChild(1).gameObject.SetActive(false);
            }

        if (z < spawner.roomCount - 1)
            if (spawner.spawnedRooms[x, z + 1] != null)
            {
                transform.GetChild(2).gameObject.SetActive(false);
            }

        if (z > 0)
            if (spawner.spawnedRooms[x, z - 1] != null)
            {
                transform.GetChild(3).gameObject.SetActive(false);
            }
    }

    public void CloseRoom()
    {
        //Debug.Log(Mathf.Round(transform.position.x / spawner.roomSize) - 1);
        int x = (int)Mathf.Round(transform.position.x / spawner.roomSize);
        int z = (int)Mathf.Round(transform.position.z / spawner.roomSize);
        if (transform.position.y < -50) return;
        if (x > 0)
            if (spawner.spawnedRooms[x - 1, z] != null)
            {
                transform.GetChild(0).gameObject.SetActive(true);
                transform.GetChild(4).gameObject.SetActive(false);
            }

        if (x < spawner.roomCount - 1)
            if (spawner.spawnedRooms[x + 1, z] != null)
            {
                transform.GetChild(1).gameObject.SetActive(true);
                transform.GetChild(5).gameObject.SetActive(false);
            }

        if (z < spawner.roomCount - 1)
            if (spawner.spawnedRooms[x, z + 1] != null)
            {
                transform.GetChild(2).gameObject.SetActive(true);
                transform.GetChild(6).gameObject.SetActive(false);
            }

        if (z > 0)
            if (spawner.spawnedRooms[x, z - 1] != null)
            {
                transform.GetChild(3).gameObject.SetActive(true);
                transform.GetChild(7).gameObject.SetActive(false);
            }
        transform.GetChild(8).gameObject.SetActive(true);

        StartCoroutine(SpawnEnemies(x, z));

    }

    private IEnumerator SpawnEnemies(int x, int z)
    {
        yield return new WaitForSeconds(9);
        MinMaxEvent?.Invoke(x, z);
        
    }
    public void SpawnEnemiesWithMinMax(int enemyCount)
    {
        float x = transform.position.x;
        float z = transform.position.z;

        int xE = (int)Mathf.Round(x / spawner.roomSize);
        int zE = (int)Mathf.Round(z / spawner.roomSize);
        SendEnemyCount?.Invoke(enemyCount, xE, zE);

        for (int i = 0; i < enemyCount; i++)
        {
            int index = Random.Range(0, enemyPrefab.Length);
            Instantiate(enemyPrefab[index], new Vector3(Random.Range(x, x + 10), 8, Random.Range(z - 10, z)), Quaternion.identity);
        }
    }
        
}

[System.Serializable]
public class SendCountEnemyEvent : UnityEvent<int, int, int> { }

[System.Serializable]
public class SendEvent : UnityEvent<int, int> { }




