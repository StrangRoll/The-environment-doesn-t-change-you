using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirsRoom : MonoBehaviour
{
    [SerializeField] private Spawner spawner;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(spawner.roomCount / 2 * spawner.roomSize, 0, spawner.roomCount / 2 * spawner.roomSize);
        int x = (int)Mathf.Round(transform.position.x / spawner.roomSize);
        int z = (int)Mathf.Round(transform.position.z / spawner.roomSize);
        if (spawner.spawnedRooms[x - 1, z] != null)
            transform.GetChild(0).gameObject.SetActive(false);

        if (spawner.spawnedRooms[x + 1, z] != null)
            transform.GetChild(1).gameObject.SetActive(false);

        if (spawner.spawnedRooms[x, z + 1] != null)
            transform.GetChild(2).gameObject.SetActive(false);

        if (spawner.spawnedRooms[x, z - 1] != null)
            transform.GetChild(3).gameObject.SetActive(false);
    }

}
