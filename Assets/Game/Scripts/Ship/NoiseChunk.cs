using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoiseChunk : MonoBehaviour 
{
	Image image;
	Color color;

	public float noise { get; private set; }

	void Awake()
	{
		noise = 0;
		image = GetComponent<Image>();
		color = image.color;
	}

	public void SetNoise(float value)
	{
		noise = value;
		color.a = value;
		image.color = color;
	}
}
