using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] PlayerLifes player;
    private float speed = 100;
    // Start is called before the first frame update
    void Start()
    {
        if (transform.position.y < -50) speed = 0;
        transform.LookAt(player.transform.position);
        transform.Rotate(Random.Range(-5f,5f), Random.Range(-5f,5f), 0);
    }

    // Update is called once per frame
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
