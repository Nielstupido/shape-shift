using UnityEngine;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]private List<Transform> spawnPoints;
    [SerializeField]private List<Sprite> shapes;
    [SerializeField]private GameObject enemy;
    private int maxAvailShapes = 3;
    private int enemyShapeNum;
    
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1f, 1f);
    }

    void SpawnEnemy()
    {
        GameObject newEnemy = Instantiate(enemy, spawnPoints[Random.Range(0, 13)].localPosition, Quaternion.identity);
        enemyShapeNum = Random.Range(0, maxAvailShapes);
        newEnemy.GetComponent<SpriteRenderer>().sprite = shapes[enemyShapeNum];
        newEnemy.GetComponent<PlayerHit>().EnemyShapeNum = enemyShapeNum;
        newEnemy.transform.SetParent(transform, false);
    }
}
