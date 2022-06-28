using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextPopupSpawner : MonoBehaviour
{
    public static void SpawnTextPopup(GameObject textPrefab, Vector3 shapeLoc)
    {
        GameObject textPopup = Instantiate(textPrefab, Camera.main.WorldToScreenPoint(shapeLoc), Quaternion.identity);
    }
}
