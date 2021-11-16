using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnterTheRoom : MonoBehaviour
{
    [SerializeField] private UnityEvent enterRoomEvent;
    public void StartRoom()
    {
        enterRoomEvent?.Invoke();
        gameObject.SetActive(false);
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(5);
    }
}
