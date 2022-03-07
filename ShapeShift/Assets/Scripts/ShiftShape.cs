using UnityEngine;
using System.Collections.Generic;

public class ShiftShape : MonoBehaviour
{
    [SerializeField]private List<Sprite> shapes;
    private int currentShape = 0;

    public int CurrentShape {get {return currentShape;}}

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Shift();
        }
    }

    public void Shift()
    {
        if(shapes.Count == currentShape + 1)
        {
            currentShape = -1;
        }
        
        gameObject.GetComponent<SpriteRenderer>().sprite = shapes[++currentShape];
    }
}
