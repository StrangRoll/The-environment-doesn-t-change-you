using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLIfe : MonoBehaviour
{
    [SerializeField] private float lifes;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Hit()
    {
        lifes--;
        Debug.Log(lifes);
        if (lifes <= 0) Destroy(gameObject);
    }
}
