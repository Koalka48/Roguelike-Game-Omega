using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public GameObject enemy;
    public float speed = 30f;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.IgnoreCollision(enemy.GetComponent<Collider>(), GetComponent<Collider>());
        Vector3 direction = transform.TransformDirection(Vector3.up);
        rb.velocity = direction * speed;
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
