using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponContoller : MonoBehaviour
{ 
    public GameObject player;
    private Vector3 offset = new Vector3(0, 1.3f, 0);
    public GameObject bullet;
    private Vector3 bulletOffset = new Vector3(0,1.1f,0);
    void Start()
    {

    }

    void Update()
    {
        if(player.IsDestroyed())
        {
            gameObject.SetActive(false);
        }
        transform.position = player.transform.position + offset;
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.rotation = Quaternion.Euler(0, 180, 0); 
            Instantiate(bullet, transform.position - bulletOffset, Quaternion.Euler(90, 0, 0));
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(0, 90, 0); 
            Instantiate(bullet, transform.position - bulletOffset, Quaternion.Euler(90, -90, 0));
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0); 
            Instantiate(bullet, transform.position - bulletOffset, Quaternion.Euler(90, 180, 0));
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(0, -90, 0); 
            Instantiate(bullet, transform.position - bulletOffset, Quaternion.Euler(90, 90, 0));
        }
    }
}
