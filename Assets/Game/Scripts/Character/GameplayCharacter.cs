using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.CharacterController;
using UnityStandardAssets.Characters.FirstPerson;

public class GameplayCharacter : MonoBehaviour 
{

	[SerializeField] RigidbodyFirstPersonController controller;
//	[SerializeField] vThirdPersonController controller;
//	[SerializeField] vThirdPersonInput input;
//	[SerializeField] vThirdPersonCamera characterCamera;
	[SerializeField] Collider characterCollider;
	[SerializeField] Rigidbody characterRigidbody;
//	[SerializeField] Animator characterAnimator;
	bool acting = false;

	bool isPilot = false;
	bool rotateShip = false;

	PlayerShipController shipController;
	PilotSeat pilotSeat;

	void Update()
	{
		if (isPilot)
		{
			if (Input.GetKeyDown(KeyCode.Tab))
			{
				rotateShip = !rotateShip;
				controller.inputEnabled = !rotateShip;
//				input.enabled = !rotateShip;
				shipController.rotate = rotateShip;
//				characterCamera.enabled = !rotateShip;
				Cursor.visible = rotateShip;
				Cursor.lockState = CursorLockMode.None;
			}
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				GetUpFromPilotChair();
			}
		}
	}

	public void SitInPilotChair(PlayerShipController spaceShip, PilotSeat chair)
	{
		if (acting)
		{
			return;
		}

		pilotSeat = chair;
		shipController = spaceShip;
		SitInChair(pilotSeat.seatPosition, ShipCommand);
	}

	public void GetUpFromPilotChair()
	{
		if (acting)
		{
			return;
		}

		rotateShip = false;
		controller.inputEnabled = !rotateShip;
//		input.enabled = !rotateShip;
		shipController.rotate = rotateShip;
//		characterCamera.enabled = !rotateShip;
		Cursor.visible = rotateShip;
		Cursor.lockState = CursorLockMode.None;
		GetUpFromChair(pilotSeat.getUpPosition, LeavePilotChair);
	}

	public void GetUpFromChair(Transform chair, System.Action onFinishAnimation)
	{
		if (acting)
		{
			return;
		}

		acting = true;
		StartCoroutine(GetUpFromChairCoroutine(chair, onFinishAnimation));
	}


	public void SitInChair(Transform chair, System.Action onFinishAnimation)
	{
		if (acting)
		{
			return;
		}

		acting = true;
		controller.lockMovement = true;
		characterCollider.enabled = false;
		characterRigidbody.isKinematic = true;
//		characterAnimator.enabled = false;
		StartCoroutine(SitInChairCoroutine(chair, onFinishAnimation));
	}

	IEnumerator SitInChairCoroutine(Transform chair, System.Action onFinishAnimation)
	{
		float elapsedTime = 0;
		Vector3 startPosition = transform.position;
		Quaternion startRotation = transform.rotation;

		do 
		{
			yield return new WaitForEndOfFrame();
			elapsedTime += Time.deltaTime * 2;

			if (elapsedTime > 1)
			{
				elapsedTime = 1;
			}
			transform.position = Vector3.Lerp(startPosition, chair.position, elapsedTime);
			transform.rotation = Quaternion.Lerp(startRotation, chair.rotation, elapsedTime);

		} while (elapsedTime < 1);

		acting = false;
		controller.lockMovement = true;
		if (onFinishAnimation != null)
		{
			onFinishAnimation();
		}
	}

	IEnumerator GetUpFromChairCoroutine(Transform newPosition, System.Action onFinishAnimation)
	{
		float elapsedTime = 0;
		Vector3 startPosition = transform.position;
		Quaternion startRotation = transform.rotation;

		do 
		{
			yield return new WaitForEndOfFrame();
			elapsedTime += Time.deltaTime * 2;

			if (elapsedTime > 1)
			{
				elapsedTime = 1;
			}
			transform.position = Vector3.Lerp(startPosition, newPosition.position, elapsedTime);
			transform.rotation = Quaternion.Lerp(startRotation, newPosition.rotation, elapsedTime);

		} while (elapsedTime < 1);

		acting = false;
		controller.lockMovement = false;
		if (onFinishAnimation != null)
		{
			onFinishAnimation();
		}
	}

	void ShipCommand()
	{
		isPilot = true;
		shipController.PilotOnBoard();
	}

	void LeavePilotChair()
	{
		isPilot = false;
		shipController.LeaveBoard();
		controller.lockMovement = false;
		characterCollider.enabled = true;
		characterRigidbody.isKinematic = false;
//		characterAnimator.enabled = true;
	}
}
