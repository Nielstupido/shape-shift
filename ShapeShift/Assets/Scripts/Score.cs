using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private static TextMeshProUGUI scoreText;
    public GameObject textPrefab;
    private static GameObject textPrefab2;
    private static int addedPoints = 1;

    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        textPrefab2 = textPrefab;
    }

    public static void AddScore(Vector3 shapePos)
    {
        TextPopupSpawner.SpawnTextPopup(textPrefab2, shapePos);
        scoreText.text = (int.Parse(scoreText.text) + addedPoints).ToString();
    }
}
