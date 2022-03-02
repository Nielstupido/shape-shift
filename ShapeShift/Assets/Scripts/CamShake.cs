using UnityEngine;

public class CamShake : MonoBehaviour
{
	[SerializeField]private Transform camTransform;
	[SerializeField]private float shakeDuration = 0.5f;
	[SerializeField]private float shakeAmount = 0.7f;
	[SerializeField]private float decreaseFactor = 1.0f;
	
	private Vector3 originalPos;
	
	void Awake()
	{
		if (camTransform == null)
		{
			camTransform = GetComponent(typeof(Transform)) as Transform;
		}
	}
	
	void OnEnable()
	{
		originalPos = camTransform.localPosition;
	}

	void Update()
	{
		if (shakeDuration > 0)
		{
			camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
			
			shakeDuration -= Time.deltaTime * decreaseFactor;
		}
		else
		{
			shakeDuration = 0f;
			camTransform.localPosition = originalPos;
		}
	}
}