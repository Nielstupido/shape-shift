 using UnityEngine;

public class CamShake : MonoBehaviour
{
	[SerializeField]private Transform cameraObject;
	private Vector3 initialPosition;
	private float shakeDuration = 0f;
	private float shakeMagnitude = 0.3f;
	private float dampingSpeed = 1.0f;

	void Start()
	{
		initialPosition = cameraObject.localPosition;
	}

	void Update()
	{
		if (shakeDuration > 0)
		{
			cameraObject.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;
			shakeDuration -= Time.deltaTime * dampingSpeed;
		}
		else
		{
			shakeDuration = 0f;
			cameraObject.localPosition = initialPosition;
		}
	}

	public void TriggerShake() 
	{
		shakeDuration = 0.5f;
	}
}