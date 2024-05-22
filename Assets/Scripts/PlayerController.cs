using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float speed = 40.0f;
    public float additionalForce = 100.0f;
    private float horizontalInput;
    private float forwardInput;
    private Rigidbody playerRb;
    public GameObject weapon;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, 0f, forwardInput).normalized;
        if (movement != Vector3.zero)
        {
            transform.forward = movement;
        }

        playerRb.velocity = movement * speed;
        playerRb.AddForce(Vector3.down * additionalForce);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Game Over!");
            gameObject.SetActive(false);
        }
    }
}
