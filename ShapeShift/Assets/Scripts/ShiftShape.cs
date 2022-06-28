using UnityEngine;
using System.Collections.Generic;

public class ShiftShape : MonoBehaviour
{
    [SerializeField]private List<Sprite> shapes;
    private int currentShape = 0;
    private int shapesNum = 2;

    public int CurrentShape {get {return currentShape;}}
    public int ShapesNum {set {shapesNum += value;}}

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Shift();
        }
    }

    public void Shift()
    {
        if(shapesNum == currentShape + 1)
        {
            currentShape = -1;
        }
        
        gameObject.GetComponent<SpriteRenderer>().sprite = shapes[++currentShape];
    }
}
