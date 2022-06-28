using TMPro;
using UnityEngine;

public class ScorePopup : MonoBehaviour
{
    void Awake()
    {
        Score scoreScript = FindObjectOfType<Score>();
        transform.SetParent(scoreScript.transform.parent);
    }

    void Start()
    {
        Vector3 targetPos = Vector3.up;
        targetPos.y += 50;
        LeanTween.alpha(gameObject, 0f, 0.5f);
        LeanTween.move(gameObject, transform.position +  targetPos, 0.55f).setOnComplete(()=>{Destroy(gameObject);});
    }
}
