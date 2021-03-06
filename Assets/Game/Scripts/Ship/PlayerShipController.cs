﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerShipController : SpaceObject 
{
	[SerializeField] Text accelerationLabel;
	[SerializeField] Text speedLabel;
	[SerializeField] Text rotationLabel;
	[SerializeField] Text gearLabel;
	[SerializeField] GameObject shipUI;
	[SerializeField] Image cursor;
	[SerializeField] float changeVelocitySpeed = 10;
	[SerializeField] float maxSpeed = 10000;
	[SerializeField] float minSpeed = -100;
	[SerializeField] float maxAccel = 100;
	[SerializeField] float minAccel = -10;
	[SerializeField] float breakSpeed = 100;
//	[SerializeField] float rotationSpeed = 10;

	public float XSensitivity = 2f;
	public float YSensitivity = 1f;
	public float ZSensitivity = 2f;

	[SerializeField] bool invertY = false;

	float acceleration = 0;
	float speed = 0;
	int gear = 1;
	float speedMultiplier = 1;

	public bool rotate = false;
	private bool pilotOnBoard = false;

	private Quaternion m_ShipTargetRot;
	float smoothTime = 16f;

	void Start()
	{
		m_ShipTargetRot = transform.localRotation;
	}

	void Update()
	{
		if (pilotOnBoard)
		{
			HandleSpeedMultiplier();
			HandleKeyboardInput();
			if (rotate)
			{
				HandleMouseInput();
			}
			UpdatePosition();
			UpdateGUI();
		}
	}

	public void PilotOnBoard()
	{
		pilotOnBoard = true;
		shipUI.SetActive(true);
	}

	public void LeaveBoard()
	{
		pilotOnBoard = false;
		shipUI.SetActive(false);
	}

	void HandleSpeedMultiplier()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			gear = 1;
			speedMultiplier = 1;
		}
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			gear = 2;
			speedMultiplier = 10;
		}
		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			gear = 3;
			speedMultiplier = 100;
		}
		if (Input.GetKeyDown(KeyCode.Alpha4))
		{
			gear = 4;
			speedMultiplier = 1000;
		}
		if (Input.GetKeyDown(KeyCode.Alpha5))
		{
			gear = 5;
			speedMultiplier = 10000;
		}
	}

	void HandleKeyboardInput()
	{
		bool isBreak = false;
		if (Input.GetKey(KeyCode.W))
		{
			acceleration = Mathf.Clamp(acceleration * speedMultiplier + changeVelocitySpeed * speedMultiplier * Time.deltaTime, minAccel * speedMultiplier, maxAccel * speedMultiplier);
		}
		if (Input.GetKey(KeyCode.S))
		{
			acceleration = Mathf.Clamp(acceleration * speedMultiplier - changeVelocitySpeed * speedMultiplier * Time.deltaTime, minAccel * speedMultiplier, maxAccel * speedMultiplier);
		}
		if (Input.GetKey(KeyCode.Space))
		{
			//Break
			acceleration = 0;
			isBreak = true;
		}
		if (Input.GetKeyDown(KeyCode.R))
		{
			rotate = !rotate;
		}

		if (acceleration != 0)
		{
			speed = Mathf.Clamp(speed + acceleration, minSpeed * speedMultiplier, maxSpeed * speedMultiplier);
		}
		else if (isBreak)
		{
			speed = Mathf.Lerp(speed, 0, breakSpeed * Time.deltaTime);
		}
	}

	void HandleMouseInput()
	{
		//TEMP cursor
		cursor.rectTransform.localPosition = Input.mousePosition - new Vector3(Screen.width / 2, Screen.height / 2, 0);
		Vector2 mousePosition = Input.mousePosition;
		mousePosition.x = (mousePosition.x - Screen.width / 2) / Screen.width;
		mousePosition.y = -(mousePosition.y - Screen.height / 2) / Screen.height;
		if (invertY)
		{
			mousePosition.y = -mousePosition.y;
		}

		float yRot = mousePosition.x * YSensitivity;
		float xRot = mousePosition.y * XSensitivity;
		float zRot = CrossPlatformInputManager.GetAxis("Tilt") * ZSensitivity;

		m_ShipTargetRot *= Quaternion.Euler(xRot, yRot, zRot);

		transform.localRotation = Quaternion.Slerp(transform.localRotation, m_ShipTargetRot,
				smoothTime * Time.deltaTime);
		
//		transform.Rotate(mousePosition.y * rotationSpeed * Time.deltaTime, mousePosition.x * rotationSpeed * Time.deltaTime, 0);
		rotationLabel.text = mousePosition.ToString();
	}

	void UpdatePosition()
	{
		realPosition += transform.forward * speed * Time.deltaTime;
	}

	void UpdateGUI()
	{
		accelerationLabel.text = acceleration.ToString();
		speedLabel.text = speed.ToString();
		gearLabel.text = gear.ToString();
	}

//	void OnDrawGizmos()
//	{
//		Gizmos.DrawSphere(transform.position + transform.forward * 10, 1);
//	}
}
