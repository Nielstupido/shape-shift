using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuShapeMovement : MonoBehaviour
{
    [SerializeField] LeanTweenType choosenEaseType;
    [SerializeField] List<Sprite> shapes = new List<Sprite>();
    WaitForSeconds delay;
    SpriteRenderer shapeComp;
    int indexCounter;

    void Start()
    {
        shapeComp = GetComponent<SpriteRenderer>();
        delay = new WaitForSeconds(.5f);
        StartCoroutine(ChangeShapesCoroutine());

        LeanTween.moveY(gameObject, 1f, 1.5f).setEase(choosenEaseType).setLoopPingPong();
    }

    IEnumerator ChangeShapesCoroutine()
    {
        indexCounter = 0;
        while(true)
        {
            if(indexCounter == 6)
            {
                indexCounter = 0;
            }
            shapeComp.sprite = shapes[indexCounter];
            indexCounter++;

            yield return delay;
        }
    }
}
