using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UiAnimator
{
    public static void MoveObj(GameObject uiElement, Vector3 targetPos, LeanTweenType easeT)
    {
        LeanTween.move(uiElement, targetPos, 0.5f).setEase(easeT);
    }

    public static void ScaleObj(GameObject btn, Vector3 scaleT, float delayDuration)
    {
        LeanTween.scale(btn, scaleT, 0.2f).delay = delayDuration;
    }

    public static void BlackOut(CanvasGroup curtain, float targetAlpha)
    {
        LeanTween.alphaCanvas(curtain, targetAlpha, 1f).setOnComplete(() => {return;});
    }
}
