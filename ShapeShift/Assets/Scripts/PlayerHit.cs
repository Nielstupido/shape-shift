using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    private PlayerStats playerStats;
    private ShiftShape shiftShape;

    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        shiftShape = FindObjectOfType<ShiftShape>();
    } 
  
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name.Equals("Shape") && shiftShape.CurrentShape == )
        {
            playerStats.Health -= 10;
            Destroy(gameObject);
        }
    }
}
