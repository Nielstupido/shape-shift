using UnityEngine;
using System.Collections.Generic;

public class ShiftShape : MonoBehaviour
{
    [SerializeField]private List<Sprite> shapes;
    [SerializeField]private GameObject curtain;
    private int currentShape = 0;
    private int shapesNum = 2;
    private bool isGamePaused = false;

    public int CurrentShape {get {return currentShape;}}
    public int ShapesNum {set {shapesNum += value;}}

    void Start()
    {
        CurtainController.AnimateCurtain(0f);
        curtain.SetActive(false);
        GameObserver.OnGameContinue += ContinueGame;
        GameObserver.OnGamePaused += PauseGame;
    }

    void OnDisable()
    {
        GameObserver.OnGameContinue -= ContinueGame;
        GameObserver.OnGamePaused -= PauseGame;  
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !isGamePaused)
        {
            Shift();
        }
    }

    public void Shift()
    {
        if(!isGamePaused)
        {
            if(shapesNum == currentShape + 1)
            {
                currentShape = -1;
            }
            
            gameObject.GetComponent<SpriteRenderer>().sprite = shapes[++currentShape];
        }
    }

    void PauseGame()
    {
        isGamePaused = true;
    }

    void ContinueGame()
    {
        isGamePaused = false;
    }
}
