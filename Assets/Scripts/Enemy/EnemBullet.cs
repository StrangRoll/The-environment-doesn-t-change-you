using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemBullet : MonoBehaviour
{
    [SerializeField] PlayerLifes player;
    private float speed = 100;
    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(player.transform);
        transform.Rotate(Random.Range(-15f, 15f), Random.Range(-15f, 15f), 0);
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
