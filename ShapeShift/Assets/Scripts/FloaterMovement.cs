using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloaterMovement : MonoBehaviour
{
    private Vector3 direction;
    private int speed;

    void Start()
    {
        direction = Vector3.left;
        speed = Random.Range(1, 5);
    }

    void Update()
    {
        gameObject.transform.position += (direction * speed * Time.deltaTime);

        if(transform.position.x < Camera.main.ScreenToWorldPoint(Vector3.zero).x - 2)
        {
            Destroy(gameObject);
        }
    }
}
