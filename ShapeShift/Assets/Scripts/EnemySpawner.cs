using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]private List<Sprite> shapes;
    [SerializeField]private GameObject enemy;
    private int maxAvailShapes = 2;
    private int enemyShapeNum, randomNum;
    private int lastShape, numberOfOccurrences;
    private float enemySpeed;
    private float spawnSpeed, difficultyLastFor, difficultyLastForX;
    private float spawnSpeedT, difficultyLastForT, difficultyLastForXT;
    private Vector3 spawnLoc;
    private bool isGameOver, isGoodToProceed, isGamePaused;

    public bool IsGameOVer {set{isGameOver = value;}}
    public int MaxAvailEnemyShapes {set{maxAvailShapes += value;}}
    
    void Start()
    {
        GameObserver.OnGamePaused += PauseGame;
        GameObserver.OnGameContinue += ContinueGame;
        
        numberOfOccurrences = 0;
        isGoodToProceed = false;
        isGameOver = false;
        isGamePaused = false;
        spawnSpeed = 3f;
        difficultyLastFor = 1f;

        StartCoroutine("GameDifficulty");
    }

    void OnDisable()
    {
        GameObserver.OnGamePaused -= PauseGame;
        GameObserver.OnGameContinue -= ContinueGame;
    }

    void SpawnEnemy(float speed)
    {
        if(!isGamePaused)
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
            newEnemy.GetComponent<EnemyMovement>().EnemySpeed = speed;
        }
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
                if(spawnSpeed >= 1)
                {
                    enemySpeed = Random.Range(2, 4);
                }
                else
                {
                    enemySpeed = Random.Range(4f, 6f);
                }

                SpawnEnemy(enemySpeed);

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
                    spawnSpeed -= 0.2f;
            }


            if(difficultyLastFor <= 10f)
                difficultyLastFor += 0.05f;
            
        }
    }

    void PauseGame()
    {
        difficultyLastForXT = difficultyLastForX;
        difficultyLastForT = difficultyLastFor;
        spawnSpeedT = spawnSpeed;
        isGamePaused = true;
    }

    void ContinueGame()
    {
        difficultyLastForX = difficultyLastForXT;
        difficultyLastFor = difficultyLastForT;
        spawnSpeed = spawnSpeedT;
        isGamePaused = false;
    }
}
