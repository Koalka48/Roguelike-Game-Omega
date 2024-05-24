using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 40.0f;
    public float additionalForce = 100.0f;
    private float horizontalInput;
    private float forwardInput;
    private Rigidbody playerRb;
    public GameObject weapon;
    private Animator playerAnim;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAnim.speed = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, 0f, forwardInput).normalized;
        if (movement != Vector3.zero)
        {
            playerAnim.SetBool("isAttacking", true);
            transform.forward = movement;
        }
        else
        {
            playerAnim.SetBool("isAttacking", false);
        }
        playerRb.velocity = movement * speed;
        playerRb.AddForce(Vector3.down * additionalForce);
    }
}
