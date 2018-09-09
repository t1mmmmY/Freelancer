using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectsVisor : MonoBehaviour 
{
	[SerializeField] Camera playerCamera;
	[SerializeField] SpaceObjectLabel labelPrefab;
	[SerializeField] Transform content;
	List<SpaceObjectLabel> allLabels = new List<SpaceObjectLabel>();

	void Start()
	{
		foreach (StarSystemObject systemObject in StarSystem.Instance.stars)
		{
			allLabels.Add(CreateLabel(systemObject));
		}
		foreach (StarSystemObject systemObject in StarSystem.Instance.planets)
		{
			allLabels.Add(CreateLabel(systemObject));
		}

		ChangeLabelsPosition();
	}

	SpaceObjectLabel CreateLabel(StarSystemObject systemObject)
	{
		SpaceObjectLabel newLabel = GameObject.Instantiate<SpaceObjectLabel>(labelPrefab, content);
		newLabel.Init(systemObject);
		return newLabel;
	}

	void LateUpdate()
	{
		ChangeLabelsPosition();
	}

	void ChangeLabelsPosition()
	{
		foreach (SpaceObjectLabel label in allLabels)
		{
			float angle = Vector3.Angle(transform.forward, label.GetStarPosition());
//			if (label.label.text == "Sun")
//			{
//				Debug.Log(angle.ToString());
//			}
			if (Mathf.Abs(angle) > 90)
			{
				label.gameObject.SetActive(false);
			}
			else
			{
				label.gameObject.SetActive(true);
				Vector3 position = label.GetStarPosition();
				position = playerCamera.WorldToScreenPoint(position);
				position.z = 0;
				position.x -= Screen.width / 2;
				position.y -= Screen.height / 2;
				label.transform.localPosition = position;
			}
		}
	}

}
