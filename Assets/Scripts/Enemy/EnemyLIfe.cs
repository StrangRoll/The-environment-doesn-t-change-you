using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyLIfe : MonoBehaviour
{
    [SerializeField] private float lifes;
    [SerializeField] private UnityEvent DeathEvent;


    public void Hit()
    {
        lifes--;
        if (lifes <= 0)
        {
            DeathEvent?.Invoke();
            Destroy(gameObject);
        }
    }
}
