using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]private List<Sprite> shapes;
    [SerializeField]private GameObject enemy;
    private int maxAvailShapes = 3;
    private int enemyShapeNum, randomNum;
    private int lastShape, numberOfOccurrences;
    private float spawnSpeed, difficultyLastFor, difficultyLastForX;
    private Vector3 spawnLoc;
    private bool isGameOver, isGoodToProceed;

    public bool IsGameOVer {set{isGameOver = value;}}
    
    void Start()
    {
        numberOfOccurrences = 0;
        isGoodToProceed = false;
        isGameOver = false;
        spawnSpeed = 3f;
        difficultyLastFor = 1f;

        StartCoroutine("GameDifficulty");
    }

    void SpawnEnemy()
    {
        GetRandomLoc();
        spawnLoc = Camera.main.ViewportToWorldPoint(spawnLoc);
        GameObject newEnemy = Instantiate(enemy, spawnLoc, Quaternion.identity);
        
        while(!isGoodToProceed)
        {
            enemyShapeNum = Random.Range(0, maxAvailShapes);
            CheckContinualIdentical();
        }

        isGoodToProceed = false;
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

    void CheckContinualIdentical()
    {
        if(lastShape == enemyShapeNum)
            numberOfOccurrences++;
        else
        {
            lastShape = enemyShapeNum;
            numberOfOccurrences = 1;
        }

        if(numberOfOccurrences >= 3)
            isGoodToProceed = false;
        else
            isGoodToProceed = true;
    }

    IEnumerator GameDifficulty()
    {
        while(!isGameOver)
        {
            difficultyLastForX = difficultyLastFor;

            while(difficultyLastForX > 0)
            {
                SpawnEnemy();

                yield return new WaitForSeconds(spawnSpeed);
                difficultyLastForX -= 0.5f;
            }

            if(spawnSpeed >= 0.5f)
            {
                if(spawnSpeed <= 1f)
                    spawnSpeed -= 0.02f;
                else if(spawnSpeed <= 1.5f)
                    spawnSpeed -= 0.05f;
                else
                    spawnSpeed -= 0.1f;
            }
            Debug.Log(spawnSpeed);
            Debug.Log(difficultyLastFor);

            if(difficultyLastFor <= 10f)
                difficultyLastFor += 0.05f;
        }
    }
}
