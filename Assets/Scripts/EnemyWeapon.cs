using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public GameObject bullet;
    public Animator anim;
    private float lastShootTime;
    public float shootInterval = 3f;
    // Start is called before the first frame update
    void Start()
    {
        lastShootTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(anim.GetBool("isAttacking"))
        {
            if(Time.time - lastShootTime >= shootInterval)
            {
                Instantiate(bullet, transform.position, Quaternion.Euler(90, transform.eulerAngles.y, 0));
                lastShootTime = Time.time;
            }
        }
    }
}
