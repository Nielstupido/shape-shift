using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private ShapeMovement player;
    private float enemySpeed = 2f;
    private bool isGamePaused;

    public float EnemySpeed { set{enemySpeed = value;}}

    void Start()
    {
        GameObserver.OnGamePaused += PauseGame;
        GameObserver.OnGameContinue += ContinueGame;

        transform.position = new Vector3(transform.position.x, transform.position.y, 2f);
        player = FindObjectOfType<ShapeMovement>();
        isGamePaused = false;
    }

    void Update()
    {
        if(!isGamePaused)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemySpeed * Time.deltaTime);
            gameObject.transform.position = SetZ(gameObject.transform.position, 2);
        }
    }

    Vector3 SetZ(Vector3 vector, float z)
    {
        vector.z = z;
        return vector;
    } 

    void PauseGame()
    {
        isGamePaused = true;
    }

    void ContinueGame()
    {
        isGamePaused = false;
    }

    void OnDestroy()
    {
        GameObserver.OnGamePaused -= PauseGame;
        GameObserver.OnGameContinue -= ContinueGame;
    }
}
