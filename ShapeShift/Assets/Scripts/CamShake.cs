using UnityEngine;

public class CamShake : MonoBehaviour
{
		// Transform of the GameObject you want to shake
	[SerializeField]private Transform cameraObject;

		// The initial position of the GameObject
	private Vector3 initialPosition;
	
	// Desired duration of the shake effect
	private float shakeDuration = 0f;
	
	// A measure of magnitude for the shake. Tweak based on your preference
	private float shakeMagnitude = 0.3f;
	
	// A measure of how quickly the shake effect should evaporate
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