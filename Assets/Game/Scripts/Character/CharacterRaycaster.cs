using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRaycaster : MonoBehaviour 
{
	[SerializeField] Camera characterCamera;
	[SerializeField] GameplayCharacter character;
	[SerializeField] ActiveObjectHint hint;
	[SerializeField] string[] layers;
	Vector2 cameraPoint = new Vector2(Screen.width / 2, Screen.height / 2);

	ActiveObject activeObject;

	void Start()
	{
		//Need to check screen size chznges
	}

	void Update()
	{
		RaycastHit hit = new RaycastHit();
		if (Physics.Raycast(characterCamera.ScreenPointToRay(cameraPoint), out hit, 10, LayerMask.GetMask(layers)))
		{
			activeObject = hit.transform.GetComponent<ActiveObject>();
			if (activeObject != null)
			{
				ShowHint(activeObject);
			}
		}
		else
		{
			activeObject = null;
			HideHint();
		}

		if (Input.GetKeyDown(KeyCode.E))
		{
			if (activeObject != null)
			{
				activeObject.DoAction(character);
			}
		}
	}

	void ShowHint(ActiveObject activeObject)
	{
		hint.ShowHint(activeObject);
	}

	void HideHint()
	{
		hint.HideHint();
	}

	void FixedUpdate()
	{
		//TEMP
		cameraPoint = new Vector2(Screen.width / 2, Screen.height / 2);
	}
}
