using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject continueBtn;
    [SerializeField] private GameObject pauseBtn;
    [SerializeField]private GameObject curtain;
    private static GameObject container;
    private Vector3 originPos, targetPos;

    void Start()
    {
        originPos = transform.position;
        container = gameObject;
        targetPos = originPos;
    }

    public void Pause()
    {
        GameObserver.GamePause();
        UiAnimator.ScaleObj(pauseBtn, Vector3.zero, 0);
        UiAnimator.ScaleObj(continueBtn, Vector3.one, 0.1f);
        targetPos.x = 180f;
        UiAnimator.MoveObj(container, targetPos, LeanTweenType.easeOutQuint);
    }

    public void Continue()
    {
        GameObserver.GameContinue();
        UiAnimator.ScaleObj(continueBtn, Vector3.zero, 0);
        UiAnimator.ScaleObj(pauseBtn, Vector3.one, 0.1f);
        targetPos.x = originPos.x;
        UiAnimator.MoveObj(container, targetPos, LeanTweenType.easeInBack);
    }

    public void Restart()
    {
        curtain.SetActive(true);
        curtain.GetComponent<CanvasGroup>().alpha = 0f;
        CurtainController.AnimateCurtain(1f);
        SceneManager.LoadScene("Game");
    }

    public void Menu()
    {
        curtain.SetActive(true);
        curtain.GetComponent<CanvasGroup>().alpha = 0f;
        CurtainController.AnimateCurtain(1f);
        SceneManager.LoadScene("MainMenu");
    }
}
