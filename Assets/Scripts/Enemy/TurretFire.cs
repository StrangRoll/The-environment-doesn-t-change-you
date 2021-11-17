using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretFire : MonoBehaviour
{
    [SerializeField] EnemyBullet bullet;
    [SerializeField] float reload;

    // Update is called once per frame
    void Start()
    {
        if (transform.position.y > -50) StartCoroutine(Turret());
    }
    IEnumerator Turret()
    {
        while (true)
        {
            yield return new WaitForSeconds(reload);
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }
}
