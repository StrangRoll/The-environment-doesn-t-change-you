using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplosion : MonoBehaviour
{
    private float speed = 100;
    [SerializeField] PlayerLifes player;

    // Start is called before the first frame update
    void Start()
    {
        if (transform.position.y < -50) speed = 0;
        transform.LookAt(player.transform.position);
        transform.Rotate(Random.Range(-10f,10f), Random.Range(-30f, 30f), 0);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
        other.gameObject.GetComponent<PlayerLifes>().Hit();
    }
}
