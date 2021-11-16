using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private Spawner spawner;
    [SerializeField] private EnemyLIfe enemyPrefab;
    [SerializeField] private int minEnemys, maxEnemys;
    private int countEnemies;

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
        if (x > 0)
            if (spawner.spawnedRooms[x - 1, z] != null)
            {
                transform.GetChild(0).gameObject.SetActive(false);
            }
                
        if (x < spawner.roomCount)
            if (spawner.spawnedRooms[x + 1, z] != null)
            {
                transform.GetChild(1).gameObject.SetActive(false);
            }

        if (z < spawner.roomCount)
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

        StartCoroutine(SpawnEnemies(transform.position.x, transform.position.z));

    }

    private IEnumerator SpawnEnemies(float x, float z)
    {
        yield return new WaitForSeconds(8);
        countEnemies = Random.Range(minEnemys, maxEnemys + 1);
        for (int i=0; i<countEnemies; i++)
        {
            Instantiate(enemyPrefab, new Vector3(Random.Range(x, x + 10), 7, Random.Range(z - 10, z)), Quaternion.identity);
        }
    }

}
