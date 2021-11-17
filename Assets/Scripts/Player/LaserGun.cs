using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : MonoBehaviour
{
    public float reloadTimer = 0.3f;

    private float fireInput;
    [SerializeField] Bullet bullet;
    private bool reload = false;

    // Update is called once per frame
    void Update()
    {
        fireInput = Input.GetAxisRaw("Fire");
        if (fireInput > 0.25 && reload == false)
        {
            Instantiate(bullet, transform.position + new Vector3(0, 0.24f, 0), Quaternion.identity);
            reload = true;
            StartCoroutine(Reload());
        }
    }
    IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadTimer);
        reload = false;
    }
}
