using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour 
{
	[SerializeField] Animator doorAnimator;

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Human")
		{
			doorAnimator.SetBool("character_nearby", true);
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Human")
		{
			doorAnimator.SetBool("character_nearby", false);
		}
	}
}
