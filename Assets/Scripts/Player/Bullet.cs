using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 100;
    Camera camera;
    Vector3 napr;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        napr = camera.transform.forward;
        napr.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(napr * speed *Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }
}
