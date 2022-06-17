using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField]private static TextMeshProUGUI scoreText;
    private static int addedPoints = 10;

    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    public static void AddScore()
    {
        scoreText.text = (int.Parse(scoreText.text) + addedPoints).ToString();
    }
}
