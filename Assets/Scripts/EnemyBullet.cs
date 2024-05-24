using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public GameObject enemy;
    private WeaponContoller weapon;
    public float speed = 30f;
    private Rigidbody rb;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody>();
        weapon = GameObject.Find("M1911").GetComponent<WeaponContoller>();
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
        else if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            gameManager.GameOver();
        }
    }
}
