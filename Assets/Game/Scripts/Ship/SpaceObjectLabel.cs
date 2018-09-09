using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceObjectLabel : MonoBehaviour 
{
	public Image image;
	public Text label;

	StarSystemObject spaceObject;

	public void Init(StarSystemObject spaceObject)
	{
		this.spaceObject = spaceObject;
		label.text = spaceObject.name;
	}

	public Vector3 GetStarRealPosition()
	{
		return spaceObject.spaceObject.realPosition;
	}

	public Vector3 GetStarPosition()
	{
		return spaceObject.spaceObject.transform.position;
	}
}
