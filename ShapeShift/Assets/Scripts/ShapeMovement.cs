using UnityEngine;

public class ShapeMovement : MonoBehaviour
{
    private float speed = 200f;
    private Rigidbody2D rb;
    private Vector2 shapeVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void MoveShape(Vector2 direction)
    {
        if(direction != Vector2.zero)
        {
            shapeVelocity = direction;
            rb.velocity = shapeVelocity * speed * Time.fixedDeltaTime;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}
