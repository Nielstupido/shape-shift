using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FlickerLights : MonoBehaviour
{
    private Light2D lightComp;
    private int counter;

    void Start()
    {
        lightComp = GetComponent<Light2D>();
    }

    public IEnumerator FlickIntensity()
    {
        counter = 0;
        while (counter < 20)
        {
            counter++;

            float r = Random.Range(0.04f, 0.1f);
            lightComp.intensity = r;

            yield return null;
        }
        
        lightComp.intensity = 0.005f;
        StopCoroutine(FlickIntensity());
    }
}
