using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class StarLight : MonoBehaviour 
{
	[SerializeField] Transform player;

	void LateUpdate()
	{
		transform.LookAt(player);
	}
}
