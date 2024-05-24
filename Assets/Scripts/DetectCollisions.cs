using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private GameManager gameManager;
    private WeaponContoller weaponContoller;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        weaponContoller = GameObject.Find("M1911").GetComponent<WeaponContoller>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy")) return;
        Destroy(other.gameObject);
        if(other.CompareTag("Player"))
        {
            gameManager.GameOver();
            return;
        }
        Destroy(gameObject);
        gameManager.UpdateScore();
    }
}
