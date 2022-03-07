using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private ShapeMovement player;
    private float enemySpeed = 1f;

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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<BoxCollider2D>(), this.GetComponent<BoxCollider2D>());
        }
    }

    Vector3 SetZ(Vector3 vector, float z)
    {
        vector.z = z;
        return vector;
    } 
}
