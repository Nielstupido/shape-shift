using UnityEngine;

public class ShapeMovement : MonoBehaviour
{
    private float speedRate = 1f;
    private float speed;
    private Rigidbody2D rb;
    private Rect cameraRect;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
        var bottomLeft = cam.ScreenToWorldPoint(Vector3.zero);
        var topRight = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, cam.pixelHeight));
 
        cameraRect = new Rect(
            bottomLeft.x,
            bottomLeft.y,
            topRight.x - bottomLeft.x,
            topRight.y - bottomLeft.y);
        
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.position = new Vector3(
        Mathf.Clamp(transform.position.x, cameraRect .xMin + 0.8f, cameraRect .xMax - 0.8f),
        Mathf.Clamp(transform.position.y, cameraRect .yMin + 0.8f, cameraRect .yMax - 0.8f),
        transform.position.z);
    }

    public void MoveShape(Vector2 direction, float joystickDistance)
    {
        if(joystickDistance > 135)
        {
            speedRate = 2.5f;
        }
        else
        {
            speedRate = 2f;
        }
        speed = speedRate * joystickDistance;
        rb.velocity = direction * speed * Time.fixedDeltaTime;
    }

    public void StopShape(Vector2 direction)
    {
        if(speed < 1)
        {
            return;
        }
        else if(speed > 150)
        {
            speed -= 10f;
        }
        else if(speed > 100)
        {
            speed -= 5f;
        }
        else
        {
            speed -= 2f;
        }
        rb.velocity = direction * speed * Time.fixedDeltaTime;
    }
}
