using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceObject : MonoBehaviour
{
	[SerializeField] Vector3 _realPosition;
	[SerializeField] bool _alwaysVisible;
	[SerializeField] GameObject graphic;
	[SerializeField] GameObject lodGraphic;

	public Vector3 realPosition
	{
		get
		{
			return _realPosition;
		}
		protected set
		{
			_realPosition = value;
		}
	}

	public bool alwaysVisible
	{
		get
		{
			return _alwaysVisible;
		}
		protected set
		{
			_alwaysVisible = value;
		}
	}

	public void EnableGraphic()
	{
		if (!graphic.activeSelf)
		{
			graphic.SetActive(true);
		}

		if (lodGraphic != null)
		{
			if (lodGraphic.activeSelf)
			{
				lodGraphic.SetActive(false);
			}
		}
	}

	public void DisableGraphic()
	{
		if (graphic.activeSelf)
		{
			graphic.SetActive(false);
		}
	}

	public void SwitchToLOD()
	{
		if (lodGraphic == null)
		{
			return;
		}

		if (!lodGraphic.activeSelf)
		{
			graphic.SetActive(false);
			lodGraphic.SetActive(true);
		}
	}
}
