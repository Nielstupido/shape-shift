using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgController : MonoBehaviour
{
    [SerializeField] private List<Sprite> bgFloaters = new List<Sprite>();
    [SerializeField] private GameObject floater;
    private int randomFloater;
    private Vector3 floaterLoc;

    void Start()
    {
        StartCoroutine(SpawnFloater());
    }

    IEnumerator SpawnFloater()
    {
        while(true)
        {
            randomFloater = Random.Range(0, 6);
            floaterLoc.x = 1.1f;
            floaterLoc.z = 1.8f;
            floaterLoc.y = Random.Range(0.05f, 0.95f);
            floaterLoc = Camera.main.ViewportToWorldPoint(floaterLoc);

            GameObject newFloater = Instantiate(floater, floaterLoc, Quaternion.identity);
            newFloater.GetComponent<SpriteRenderer>().sprite = bgFloaters[randomFloater];
            newFloater.transform.position = SetZ(newFloater.transform.position);

            yield return new WaitForSeconds(Random.Range(0.03f, 0.9f));
        }
    }

    Vector3 SetZ(Vector3 vector)
    {
        vector.z = 1.8f;
        return vector;
    } 
}
