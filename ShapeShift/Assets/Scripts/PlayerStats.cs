using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private PlayerHealth playerHealth;
    private GameOver gameOver;
    private int health = 100;

    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        gameOver = FindObjectOfType<GameOver>();
    }

    public int Health 
    { 
        set 
        {
            health = value; 
            playerHealth.Health = health;
            CheckGameOver();
        } 

        get
        {
            return health;
        }
    }

    void CheckGameOver()
    {
        if(health == 0)
        {
            gameOver.GameIsOver();
        }
    }
}