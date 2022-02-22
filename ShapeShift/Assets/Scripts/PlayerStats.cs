using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private int health = 100;

    public int Health 
    { 
        set 
        {
            health = value; 
            Debug.Log(health);
        } 

        get
        {
            return health;
        }
    }
}
