using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    [SerializeField]private ParticleSystem explosion;
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
                GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<SpriteRenderer>().enabled = false;

                explosion.Play();

                playerStats.Health -= 10;
                camShake.TriggerShake();
                Destroy(gameObject, 0.5f);
            }

        }
    }
}
