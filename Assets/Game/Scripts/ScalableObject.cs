using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalableObject : SpaceObject
{
	[SerializeField] float _realSize = 10;

	public float realSize
	{
		get
		{
			return _realSize;
		}
	}

	void Start()
	{
		DistanceManager.Instance.AddScalableObject(this);
	}
}
