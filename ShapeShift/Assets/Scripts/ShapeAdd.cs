using UnityEngine;
using System.Collections;

public class ShapeAdd : MonoBehaviour
{
    [SerializeField]private GameObject text;
    private ShiftShape shiftShape;
    private EnemySpawner enemySpawner;
    private int counter, counterBreakpoint, shapesAdded;
    private bool isAddingShapesDone;

    void Start()
    {
        shiftShape = FindObjectOfType<ShiftShape>();
        enemySpawner = FindObjectOfType<EnemySpawner>();
        counter = 0;
        shapesAdded = 0;
        counterBreakpoint = 30;
        isAddingShapesDone = false;
        StartCoroutine("CountdownAddingShape");
    }

    void ShowNewAddedShape()
    {
        text.SetActive(true);
        shiftShape.ShapesNum = 1;
        enemySpawner.MaxAvailEnemyShapes = 1;
    }

    IEnumerator CountdownAddingShape()
    {
        while(!isAddingShapesDone)
        {
            if(text.activeSelf)
            {
                text.SetActive(false);
            }

            if(counter == counterBreakpoint)
            {
                ShowNewAddedShape();

                if(shapesAdded == 0)
                    counterBreakpoint = 45;
                else if(shapesAdded == 1)
                    counterBreakpoint = 65;
                else if(shapesAdded == 2)
                    counterBreakpoint = 85;
                else
                {
                    text.SetActive(false);
                    isAddingShapesDone = true;
                    StopCoroutine(CountdownAddingShape());
                }

                counter = 0;
                shapesAdded++;
            }

            counter++;

            yield return new WaitForSeconds(0.5f);
        }
        
    }
}
