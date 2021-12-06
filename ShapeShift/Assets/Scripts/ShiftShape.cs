using UnityEngine;
using System.Collections.Generic;

public class ShiftShape : MonoBehaviour
{
    [SerializeField]private List<Sprite> shapes;
    private int maxAvailableShapes = 3, currentShape = 0;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Shift();
        }
    }

    public void Shift()
    {
        if(maxAvailableShapes == currentShape + 1 || shapes.Count == currentShape + 1)
        {
            currentShape = -1;
        }
        
        gameObject.GetComponent<SpriteRenderer>().sprite = shapes[++currentShape];
    }
}
