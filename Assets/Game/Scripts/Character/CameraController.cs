using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour 
{
	[SerializeField] Transform headBone;
	[SerializeField] float lerpSpeed = 10;
	public float rotationSensitivity = 3.5f; // The sensitivity of rotation
	public float yMinLimit = -20; // Min vertical angle
	public float yMaxLimit = 80; // Max vertical angle

	Vector2 angle = Vector2.zero;

	void LateUpdate()
	{
		angle.x += Input.GetAxis("Mouse X") * rotationSensitivity;
		angle.y = ClampAngle(angle.y - Input.GetAxis("Mouse Y") * rotationSensitivity, yMinLimit, yMaxLimit);

		Quaternion rotation = Quaternion.AngleAxis(angle.x, transform.right) * Quaternion.AngleAxis(angle.y, transform.right);
		 
		headBone.localRotation = rotation;
	}

	private float ClampAngle (float angle, float min, float max) 
	{
		if (angle < -360) angle += 360;
		if (angle > 360) angle -= 360;
		return Mathf.Clamp (angle, min, max);
	}
}
