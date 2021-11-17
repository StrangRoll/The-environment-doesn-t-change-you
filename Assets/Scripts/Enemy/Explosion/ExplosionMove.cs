using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionMove : MonoBehaviour
{
    [SerializeField] EnemyExplosion bullet;
    [SerializeField] float reload;
    [SerializeField] PlayerLifes player;

    void Start()
    {
        if (transform.position.y > -50) StartCoroutine(Explosion());
    }

    void Update()
    {
        transform.LookAt(player.transform.position);
    }
    IEnumerator Explosion()
    {
        while (true)
        {
            yield return new WaitForSeconds(reload);
            StartCoroutine(Fire());
        }
    }
    IEnumerator Fire()
    {
        int bulletCount = Random.Range(50, 70);
        for (int i = 0; i < bulletCount; i++)
        {
            yield return new WaitForSeconds(0.01f);
            Instantiate(bullet, transform.position + Vector3.up, Quaternion.identity);
        }
    }

}
