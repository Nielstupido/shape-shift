using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]private List<Sprite> shapes;
    [SerializeField]private GameObject enemy;
    private int maxAvailShapes = 3;
    private int enemyShapeNum, randomNum;
    private float gameRunningFor;
    private Vector3 spawnLoc;
    
    void Start()
    {
        gameRunningFor = 3f;

        StartCoroutine("GameDifficulty");
    }

    void SpawnEnemy()
    {
        GetRandomLoc();
        spawnLoc = Camera.main.ViewportToWorldPoint(spawnLoc);
        GameObject newEnemy = Instantiate(enemy, spawnLoc, Quaternion.identity);
        enemyShapeNum = Random.Range(0, maxAvailShapes);
        newEnemy.GetComponent<SpriteRenderer>().sprite = shapes[enemyShapeNum];
        newEnemy.GetComponent<PlayerHit>().EnemyShapeNum = enemyShapeNum;
    }

    void GetRandomLoc()
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

        spawnLoc.z = 2f;
    }

    IEnumerator GameDifficulty()
    {
        while(gameRunningFor > 0)
        {
            SpawnEnemy();
        
            if(gameRunningFor <= 0.5f)
                gameRunningFor -= 0.1f;
            else
                gameRunningFor -= 0.2f;

            Debug.Log(gameRunningFor);

            yield return new WaitForSeconds(gameRunningFor);
        }
    }
}
