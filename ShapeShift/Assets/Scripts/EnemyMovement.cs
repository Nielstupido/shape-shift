using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private ShapeMovement player;
    private float enemySpeed = 0.8f;

    void Start()
    {
        player = FindObjectOfType<ShapeMovement>();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemySpeed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<BoxCollider2D>(), this.GetComponent<BoxCollider2D>());
        }
    }
}
