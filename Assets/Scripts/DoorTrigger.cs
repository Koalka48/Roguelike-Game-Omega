using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public int enemiesCount;
    public GameObject door;
    public GameObject player;
    public GameObject winPortal;
    private bool isTriggered = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        enemiesCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if(isTriggered && enemiesCount > 0)
        {
            door.SetActive(true);
        }
        else if (enemiesCount <= 0)
        { 
            door.SetActive(false);
            Debug.Log("Должно работать!");
            winPortal.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            isTriggered = true;
        }
    }
}
