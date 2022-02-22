using UnityEngine;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]private List<Transform> spawnPoints;
    [SerializeField]private List<Sprite> shapes;
    [SerializeField]private GameObject enemy;
    private int maxAvailShapes;
    
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1f, 1f);
    }

    void SpawnEnemy()
    {
        GameObject newEnemy = Instantiate(enemy, spawnPoints[Random.Range(0, 13)].localPosition, Quaternion.identity);
        newEnemy.GetComponent<SpriteRenderer>().sprite = shapes[Random.Range(0, maxAvailShapes-1)];
        newEnemy.transform.SetParent(transform, false);
    }
}
