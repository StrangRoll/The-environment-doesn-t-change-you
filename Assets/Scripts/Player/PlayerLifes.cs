using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifes : MonoBehaviour
{
    [SerializeField] private int lifes;
    void Start()
    {
        
    }

    public void Hit()
    {
        Debug.Log(lifes);
        lifes--;
        if (lifes <= 0)
        {
            Destroy(gameObject);
        }
    }
}
