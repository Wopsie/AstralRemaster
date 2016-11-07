using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {

	private Vector3 originalPos;

	void Update()
	{
		StartCoroutine(camShake(0.25f, 4f));
	}

	public IEnumerator camShake(float duration, float amount)
	{
		float endTime = Time.time + duration;

		while(duration > 0)
		{
			transform.position = originalPos + Random.insideUnitSphere * amount;
			duration -= Time.deltaTime;
			yield return null;
		}

		transform.position = originalPos;
	}
}
