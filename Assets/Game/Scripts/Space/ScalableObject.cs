using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalableObject : SpaceObject
{
	[SerializeField] float _radius = 1000;
	float _realSize = 10;

	public float realSize
	{
		get
		{
			return _radius * 2;
		}
	}

	void Start()
	{
		DistanceManager.Instance.AddScalableObject(this);
	}
}
