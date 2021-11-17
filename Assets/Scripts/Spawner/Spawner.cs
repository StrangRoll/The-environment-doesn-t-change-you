using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{

    [SerializeField] private Room[] roomPrefab;
    [HideInInspector] public Room[,] spawnedRooms;
    [HideInInspector] public int roomSize = 20;

    [SerializeField] private RoomSender sendRoomEvent;

    public int roomCount;

    void Awake()
    {
        spawnedRooms = new Room[roomCount, roomCount];
        spawnedRooms[roomCount / 2, roomCount / 2] = roomPrefab[0];
        for (int i = 0; i < roomCount; i++)
        {
            roomSpawner();
        }
        sendRoomEvent?.Invoke(spawnedRooms);
    }


    private void roomSpawner()
    {
        List<Vector3> vacantPlaces = new List<Vector3>();
        for (int x = 0; x < spawnedRooms.GetLength(0); x++)
            for (int z = 0; z < spawnedRooms.GetLength(1); z++)
            {
                if (spawnedRooms[x, z] == null) continue;

                if (x > 0 && spawnedRooms[x - 1, z] == null) vacantPlaces.Add(new Vector3(x - 1, 0, z));
                if (z > 0 && spawnedRooms[x, z - 1] == null) vacantPlaces.Add(new Vector3(x, 0, z - 1));
                if (x < roomCount - 1 && spawnedRooms[x + 1, z] == null) vacantPlaces.Add(new Vector3(x + 1, 0, z));
                if (z < roomCount - 1 && spawnedRooms[x, z + 1] == null) vacantPlaces.Add(new Vector3(x, 0, z + 1));
            }

        Room newRoom = roomPrefab[Random.Range(0, roomPrefab.Length)];
        Vector3 newRoomPosition = vacantPlaces[Random.Range(0, vacantPlaces.Count)];
        spawnedRooms[(int)newRoomPosition.x, (int)newRoomPosition.z] = Instantiate(newRoom, newRoomPosition * roomSize, newRoom.transform.rotation);
    }
}

[System.Serializable]
public class RoomSender : UnityEvent<Room[,]> { }

