using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoSpawn : MonoBehaviour
{
    [SerializeField] private UnityEvent spawnerEvent;
    // Start is called before the first frame update
    void Start()
    {
        if (transform.position.y > -50)
        {
            StartCoroutine(DoSpawner());
        }
    }
    IEnumerator DoSpawner()
    {
        yield return new WaitForSeconds(35);
        spawnerEvent?.Invoke();
        GetComponent<EnemyLIfe>().Death();
    }
}
