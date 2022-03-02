using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private PlayerHealth playerHealth;
    private int health = 100;

    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    public int Health 
    { 
        set 
        {
            health = value; 
            playerHealth.Health = health;
        } 

        get
        {
            return health;
        }
    }
}
