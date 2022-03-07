using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    private PlayerStats playerStats;
    private ShiftShape shiftShape;
    private CamShake camShake;
    private int enemyShapeNum;

    public int EnemyShapeNum { set{enemyShapeNum = value;} }

    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        shiftShape = FindObjectOfType<ShiftShape>();
        camShake = FindObjectOfType<CamShake>();
    } 
  
    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.name.Equals("Shape"))
        {
            if (shiftShape.CurrentShape == enemyShapeNum)
            {
                Destroy(gameObject);
            }
            else
            {
                camShake.gameObject.SetActive(true);
                playerStats.Health -= 10;
                Destroy(gameObject);
                camShake.TriggerShake();
            }

        }
    }
}
