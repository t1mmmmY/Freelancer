using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	[SerializeField] float walkSpeed = 4;
	[SerializeField] float runSpeed = 8;
	[SerializeField] float jumpForce = 2;
	[SerializeField] float rotationSpeed = 180;

//	[SerializeField] float changeVelocitySpeed = 10;
//	[SerializeField] float maxSpeed = 10000;
//	[SerializeField] float minSpeed = -100;
//	[SerializeField] float maxAccel = 100;
//	[SerializeField] float minAccel = -10;
//	[SerializeField] float breakSpeed = 100;
//	[SerializeField] float rotationSpeed = 10;
//
//	[SerializeField] bool invertY = false;
//
//	float acceleration = 0;
//	float speed = 0;
//	int gear = 1;
//	float speedMultiplier = 1;
//
//	public bool rotate = false;
//	private bool pilotOnBoard = false;
//
//	void Update()
//	{
//		HandleKeyboardInput();
//		if (rotate)
//		{
//			HandleMouseInput();
//		}
//		UpdatePosition();
//	}
//
//	void HandleKeyboardInput()
//	{
//		bool isBreak = true;
//		if (Input.GetKey(KeyCode.W))
//		{
//			acceleration = Mathf.Clamp(acceleration * speedMultiplier + changeVelocitySpeed * speedMultiplier * Time.deltaTime, minAccel * speedMultiplier, maxAccel * speedMultiplier);
//			isBreak = false;
//		}
//		if (Input.GetKey(KeyCode.S))
//		{
//			acceleration = Mathf.Clamp(acceleration * speedMultiplier - changeVelocitySpeed * speedMultiplier * Time.deltaTime, minAccel * speedMultiplier, maxAccel * speedMultiplier);
//			isBreak = false;
//		}
//		if (Input.GetKey(KeyCode.Space))
//		{
//			//Jump
////			acceleration = 0;
////			isBreak = true;
//		}
//
//		if (acceleration != 0)
//		{
//			speed = Mathf.Clamp(speed + acceleration, minSpeed * speedMultiplier, maxSpeed * speedMultiplier);
//		}
//		else if (isBreak)
//		{
//			speed = Mathf.Lerp(speed, 0, breakSpeed * Time.deltaTime);
//		}
//	}
//
//	void HandleMouseInput()
//	{
//		//TEMP cursor
//		Vector2 mousePosition = Input.mousePosition;
//		mousePosition.x = (mousePosition.x - Screen.width / 2) / Screen.width;
//		mousePosition.y = -(mousePosition.y - Screen.height / 2) / Screen.height;
//		if (invertY)
//		{
//			mousePosition.y = -mousePosition.y;
//		}
//
//		transform.Rotate(mousePosition.y * rotationSpeed * Time.deltaTime, mousePosition.x * rotationSpeed * Time.deltaTime, 0);
//	}
//
//	void UpdatePosition()
//	{
//		transform.position += transform.forward * speed * Time.deltaTime;
//	}
}
