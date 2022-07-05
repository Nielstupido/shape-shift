using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurtainController : MonoBehaviour
{
    [SerializeField]private CanvasGroup curtain;
    private static CanvasGroup _curtain;

    void Awake()
    {
        _curtain = curtain;
    }

    public static void AnimateCurtain(float targetAlpha)
    {
        UiAnimator.BlackOut(_curtain, targetAlpha);
    }
}
