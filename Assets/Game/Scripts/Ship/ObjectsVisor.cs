using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectsVisor : MonoBehaviour 
{
	[SerializeField] Camera playerCamera;
	[SerializeField] RectTransform canvasRect;
	[SerializeField] SpaceObjectLabel labelPrefab;
	[SerializeField] Transform content;
	List<SpaceObjectLabel> allLabels = new List<SpaceObjectLabel>();

	void Start()
	{
		GameManager.OnChangePlayerState += OnChangePlayerState;

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

	void OnDestroy()
	{
		GameManager.OnChangePlayerState -= OnChangePlayerState;
	}

	void OnChangePlayerState(PlayerState playerState)
	{
		
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
				position.x -= canvasRect.sizeDelta.x / 2;
				position.y -= canvasRect.sizeDelta.y / 2;
				label.transform.localPosition = position;
			}
		}
	}

}
