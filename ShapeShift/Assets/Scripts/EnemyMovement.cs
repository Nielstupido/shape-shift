using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private ShapeMovement player;
    private float enemySpeed = 5f;

    void Start()
    {
        player = FindObjectOfType<ShapeMovement>();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemySpeed * Time.deltaTime);
    }

}
