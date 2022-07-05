using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private static Text scoreText;
    public GameObject textPrefab;
    private static GameObject textPrefab2;
    private static int addedPoints = 1;

    public string ScoreT {get{return scoreText.text;}}

    void Start()
    {
        scoreText = GetComponent<Text>();
        textPrefab2 = textPrefab;
    }

    public static void AddScore(Vector3 shapePos)
    {
        TextPopupSpawner.SpawnTextPopup(textPrefab2, shapePos);
        scoreText.text = (int.Parse(scoreText.text) + addedPoints).ToString();
    }
}
