using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    public GameObject[ ] enemiesPrefabs;
    private float spawnRangeX = 20f;
    private float spawnRangeZ = 37f;
    private int enemyIndex;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SpawnRandEnemy();
        }
    }
    void SpawnRandEnemy(){
        enemyIndex = Random.Range(0, enemiesPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, Random.Range(-spawnRangeZ, spawnRangeZ));
        if(enemyIndex == 1)
        {
            spawnPos.y = 2f;
        }
        Instantiate(enemiesPrefabs[enemyIndex], spawnPos, Quaternion.Euler(0, Random.Range(-360,360),0));
    }
}
