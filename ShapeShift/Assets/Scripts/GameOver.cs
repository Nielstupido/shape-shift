using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private Text scoreT;
    [SerializeField] private Text highscoreT;
    private Text scoreLabel;
    private GameObject restartBtn;
    private GameObject homeBtn;
    private static GameObject _restartBtn;
    private static GameObject _homeBtn;
    private Score score;
    private Vector3 targetPosR, targetPosH;
    private int highScore;

    void Awake()
    {
        score = FindObjectOfType<Score>();
        restartBtn = GameObject.FindGameObjectWithTag("RestartBtn");
        homeBtn = GameObject.FindGameObjectWithTag("HomeBtn");
        highScore = PlayerPrefs.GetInt("HighScore");
    }

    void Start()
    {
        _restartBtn = restartBtn;
        _homeBtn = homeBtn;
        targetPosR = restartBtn.transform.position;
        targetPosH = homeBtn.transform.position;
        targetPosR.y = 135f;
        targetPosH.y = 135f;
    }

    public void GameIsOver()
    {
        panel.SetActive(true);
        scoreLabel = GameObject.FindGameObjectWithTag("ScoreLabel").GetComponent<Text>();
        if(int.Parse(score.ScoreT) > highScore)
        {
            PlayerPrefs.SetInt("HighScore", int.Parse(score.ScoreT));
            highscoreT.text = score.ScoreT;
            scoreLabel.text = "New High Score!";
        }
        else
        {
            highscoreT.text = highScore.ToString();
        }

        GameObserver.GamePause();
        scoreT.text = score.ScoreT;
        UiAnimator.MoveObj(_restartBtn, targetPosR, LeanTweenType.easeOutQuint);
        UiAnimator.MoveObj(_homeBtn, targetPosH, LeanTweenType.easeOutQuint);

    }
}
