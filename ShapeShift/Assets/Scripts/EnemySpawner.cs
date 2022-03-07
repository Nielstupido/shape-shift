using UnityEngine;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]private List<Sprite> shapes;
    [SerializeField]private GameObject enemy;
    private int maxAvailShapes = 3;
    private int enemyShapeNum, randomNum;
    private Vector3 spawnLoc;
    
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1f, 3f);
    }

    void SpawnEnemy()
    {
        randomNum = Random.Range(1, 5);

        if(randomNum == 1)
        {
            spawnLoc.x = Random.Range(0.0f, 1.1f);
            spawnLoc.y = 1.1f;
        }
        else if(randomNum == 2)
        {
            spawnLoc.x = 1.1f;
            spawnLoc.y = Random.Range(0.0f, 1.1f);
        }
        else if(randomNum == 3)
        {
            spawnLoc.x = -0.1f;
            spawnLoc.y = Random.Range(0.0f, 1.1f);
        }
        else
        {
            spawnLoc.x = -0.1f;
            spawnLoc.y = Random.Range(0.0f, 1.1f);
        }

        Debug.Log(spawnLoc);

        spawnLoc.z = 2f;

        spawnLoc = Camera.main.ViewportToWorldPoint(spawnLoc);
        GameObject newEnemy = Instantiate(enemy, spawnLoc, Quaternion.identity);
        enemyShapeNum = Random.Range(0, maxAvailShapes);
        newEnemy.GetComponent<SpriteRenderer>().sprite = shapes[enemyShapeNum];
        newEnemy.GetComponent<PlayerHit>().EnemyShapeNum = enemyShapeNum;
        
    }
}
