using UnityEngine;
using System.Collections;

public class ShapeAdd : MonoBehaviour
{
    [SerializeField]private GameObject text;
    private ShiftShape shiftShape;
    private EnemySpawner enemySpawner;
    private int counter, counterBreakpoint, shapesAdded, shapeBannerTimer;
    private int counterT, counterBreakpointT, shapesAddedT, shapeBannerTimerT;
    private bool isAddingShapesDone;
    private bool isGamePaused;

    void Start()
    {
        GameObserver.OnGameContinue += ContinueGame;
        GameObserver.OnGamePaused += PauseGame;

        shiftShape = FindObjectOfType<ShiftShape>();
        enemySpawner = FindObjectOfType<EnemySpawner>();
        isGamePaused = false;
        counter = 0;
        shapesAdded = 0;
        counterBreakpoint = 30;
        shapeBannerTimer = 0;
        isAddingShapesDone = false;
        StartCoroutine("CountdownAddingShape");
    }

    void OnDisable()
    {
        GameObserver.OnGameContinue -= ContinueGame;
        GameObserver.OnGamePaused -= PauseGame;  
    }

    void ShowNewAddedShape()
    {
        if(!isGamePaused)
        {
            text.SetActive(true);
            shiftShape.ShapesNum = 1;
            enemySpawner.MaxAvailEnemyShapes = 1;
        }
    }

    IEnumerator CountdownAddingShape()
    {
        while(!isAddingShapesDone)
        {
            if(text.activeSelf)
            {
                shapeBannerTimer++;
                if(shapeBannerTimer == 3)
                {
                    text.SetActive(false);
                    shapeBannerTimer = 0;
                }
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

    void PauseGame()
    {
        shapeBannerTimerT = shapeBannerTimer;
        counterT = counter;
        counterBreakpointT = counterBreakpoint;
        shapesAddedT = shapesAdded;
        isGamePaused = true;
    }

    void ContinueGame()
    {
        shapeBannerTimer = shapeBannerTimerT;
        counter = counterT;
        counterBreakpoint = counterBreakpointT;
        shapesAdded = shapesAddedT;
        isGamePaused = false;
    }
}
