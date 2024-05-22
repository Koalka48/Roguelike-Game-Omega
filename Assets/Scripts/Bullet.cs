using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 30f;
    private Rigidbody rb;
    public Rigidbody playerrb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Vector3 direction = transform.TransformDirection(Vector3.up);
        rb.velocity = direction * speed;
        Physics.IgnoreLayerCollision(0,3);
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}

