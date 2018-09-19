using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class DistanceManager : BaseSingleton<DistanceManager> 
{
	[SerializeField] PlayerShipController player;
	[SerializeField] List<ScalableObject> scalableObjects = new List<ScalableObject>();
	[SerializeField] float scaleFactor = 1000;

	public float maxDistance { get; private set; }

	protected override void Awake()
	{
		base.Awake();
		maxDistance = 100000;
//		maxDistance = 1000;
	}

	void Start()
	{
	}

	public void AddScalableObject(ScalableObject obj)
	{
		if (!scalableObjects.Contains(obj))
		{
			scalableObjects.Add(obj);
		}
	}

//	void Update()
//	{
//		foreach (ScalableObject obj in scalableObjects)
//		{
//			bool objectDisabled = false;
//			float realDistance = Vector3.Distance(player.realPosition, obj.realPosition);
//
//			//My formula
//			//			float angleSize = Mathf.Rad2Deg * 2 * Mathf.Asin(objectSize / 2 / Mathf.Pow(Mathf.Pow(realDistance, 2.0f) + Mathf.Pow(objectSize / 2, 2.0f), 0.5f));
//			//Wiki formula
//			float viewAngle = 2 * Mathf.Atan((obj.realSize * 1000) / (2 * realDistance));
//			if (viewAngle < 30.0f * Mathf.Deg2Rad)
//			{
//				if (obj.alwaysVisible)
//				{
//					viewAngle = 30.0f * Mathf.Deg2Rad;
//					obj.SwitchToLOD();
//				}
//				else
//				{
//					obj.DisableGraphic();
//					objectDisabled = true;
//				}
//			}
//			else
//			{
//				obj.EnableGraphic();
//			}
//
//			if (!objectDisabled)
//			{
//				float sizeCoef = 2 * 1000 / obj.realSize * Mathf.Tan(viewAngle / 2);
//				obj.transform.localScale = Vector3.one * sizeCoef;
//			}
//
//			if (realDistance > maxDistance)
//			{
//				obj.transform.position = Vector3.ClampMagnitude(obj.realPosition - player.realPosition, maxDistance);
//
//			}
//			else 
//			{
//				Debug.Log(realDistance.ToString());
//				obj.transform.position = obj.realPosition - player.realPosition;
//			}
//		}
//	}

	void Update()
	{
		foreach (ScalableObject obj in scalableObjects)
		{
			bool objectDisabled = false;
			float realDistance = Vector3.Distance(player.realPosition, obj.realPosition);
			if (realDistance > maxDistance)
			{
				//My formula
				//			float angleSize = Mathf.Rad2Deg * 2 * Mathf.Asin(objectSize / 2 / Mathf.Pow(Mathf.Pow(realDistance, 2.0f) + Mathf.Pow(objectSize / 2, 2.0f), 0.5f));
				//Wiki formula
				float viewAngle = 2 * Mathf.Atan(obj.realSize * scaleFactor / (2 * realDistance));
				if (viewAngle < 20.0f * Mathf.Deg2Rad)
				{
					if (obj.alwaysVisible)
					{
						viewAngle = 20.0f * Mathf.Deg2Rad;
						obj.SwitchToLOD();
					}
					else
					{
						obj.DisableGraphic();
						objectDisabled = true;
					}
				}
				else
				{
					obj.EnableGraphic();
				}

				if (!objectDisabled)
				{
//					float sizeCoef = 2 * scaleFactor / obj.realSize * Mathf.Tan(viewAngle / 2);
					float sizeCoef = 2 * 1000 / obj.realSize * Mathf.Tan(viewAngle / 2);
					obj.transform.localScale = Vector3.one * sizeCoef;

					obj.transform.position = Vector3.ClampMagnitude(obj.realPosition - player.realPosition, maxDistance);
				}
			}
			else 
			{
				if (obj.transform.localScale != Vector3.one)
				{
					obj.transform.localScale = Vector3.one;
				}
				obj.transform.position = obj.realPosition - player.realPosition;
			}
		}
	}


}
