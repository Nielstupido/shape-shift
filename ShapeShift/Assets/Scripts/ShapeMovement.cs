using UnityEngine;

public class ShapeMovement : MonoBehaviour
{
    private float speedRate = 1f;
    private float speed;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void MoveShape(Vector2 direction, float joystickDistance)
    {
        joystickDistance *= 5f;
        speed = speedRate * joystickDistance;
        rb.velocity = direction * speed * Time.fixedDeltaTime;
    }
}
