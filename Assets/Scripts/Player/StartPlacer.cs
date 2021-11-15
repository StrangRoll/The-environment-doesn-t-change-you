using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPlacer : MonoBehaviour
{
    [SerializeField] private Spawner spawner;
    // Start is called before the first frame update
    void Start()
    {
      
        transform.position = new Vector3(spawner.roomCount / 2 * spawner.roomSize, 1, spawner.roomCount / 2 * spawner.roomSize);
    }
}
