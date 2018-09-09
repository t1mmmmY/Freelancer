using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeDistance : MonoBehaviour 
{
	[SerializeField] Transform player;
	[SerializeField] double realDistance = 900;
	[SerializeField] float maxDistance = 1000;
	[SerializeField] double objectSize = 10;

	void Update()
	{
		if (realDistance > maxDistance)
		{
			//My formula
//			float angleSize = Mathf.Rad2Deg * 2 * Mathf.Asin(objectSize / 2 / Mathf.Pow(Mathf.Pow(realDistance, 2.0f) + Mathf.Pow(objectSize / 2, 2.0f), 0.5f));
			//Wiki formula
			double viewAngle = 2 * System.Math.Atan(objectSize / (2 * realDistance));
			float sizeCoef = 2 * (float)System.Math.Tan(viewAngle / 2);
			transform.localScale = Vector3.one * sizeCoef;
			transform.position = new Vector3(0, 0, maxDistance);
		}
		else 
		{
			if (transform.localScale != Vector3.one)
			{
				transform.localScale = Vector3.one;
			}
			transform.position = new Vector3(0, 0, (float)realDistance);
		}
	}

}
