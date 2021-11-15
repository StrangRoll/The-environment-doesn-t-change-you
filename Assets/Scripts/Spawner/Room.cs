using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private Spawner spawner;

    void Start()
    {
        //Debug.Log(Mathf.Round(transform.position.x / spawner.roomSize) - 1);
        int x = (int)Mathf.Round(transform.position.x / spawner.roomSize);
        int z = (int)Mathf.Round(transform.position.z / spawner.roomSize);
        if (x > 0)
            if (spawner.spawnedRooms[x - 1, z] != null)
                transform.GetChild(0).gameObject.SetActive(false);

        if (x < spawner.roomCount)
            if (spawner.spawnedRooms[x + 1, z] != null)
                transform.GetChild(1).gameObject.SetActive(false);

        if (z < spawner.roomCount)
            if (spawner.spawnedRooms[x, z + 1] != null)
                transform.GetChild(2).gameObject.SetActive(false);

        if (z > 0)
            if (spawner.spawnedRooms[x, z - 1] != null)
                transform.GetChild(3).gameObject.SetActive(false);
    }

}
