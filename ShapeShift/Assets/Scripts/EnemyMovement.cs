using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private ShapeMovement player;
    private float enemySpeed = 2f;

    public float EnemySpeed { set{enemySpeed = value;}}

    void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 2f);
        player = FindObjectOfType<ShapeMovement>();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemySpeed * Time.deltaTime);
        gameObject.transform.position = SetZ(gameObject.transform.position, 2);
    }

    Vector3 SetZ(Vector3 vector, float z)
    {
        vector.z = z;
        return vector;
    } 
}
