using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenNoise : MonoBehaviour 
{
	[Range(0.0f, 1.0f)]
	[SerializeField] float noiseLevel = 0;
	[SerializeField] float step = 10;
	float oldNoiseLevel = 0;

	NoiseChunk[] noiseChunks;

	enum NoiseState
	{
		Increase,
		Decrease,
		Equal
	}

	NoiseState noiseState = NoiseState.Equal;

	void Start()
	{
		oldNoiseLevel = noiseLevel;
		noiseChunks = GetComponentsInChildren<NoiseChunk>();
//		StopCoroutine("NoiseCoroutine");
//		StartCoroutine("NoiseCoroutine");
	}

	void FixedUpdate()
	{
		if (noiseLevel > 0)
		{
			if (noiseLevel > oldNoiseLevel)
			{
				noiseState = NoiseState.Increase;
			}
			else if (noiseLevel < oldNoiseLevel)
			{
				noiseState = NoiseState.Decrease;
			}
			else
			{
				noiseState = NoiseState.Equal;
			}
			RandomNoise(noiseLevel, noiseState);
		}
		else if (noiseLevel == 0 && noiseLevel != oldNoiseLevel)
		{
			MakeClear();
		}
		oldNoiseLevel = noiseLevel;
	}

//	IEnumerator NoiseCoroutine()
//	{
//		do
//		{
//			yield return new WaitForFixedUpdate();
//
//			if (noiseLevel > 0)
//			{
//				RandomNoise(noiseLevel);
//			}
//			else if (noiseLevel == 0 && noiseLevel != oldNoiseLevel)
//			{
//				MakeClear();
//			}
//			oldNoiseLevel = noiseLevel;
//
//		} while (true);
//	}

	void RandomNoise(float value, NoiseState noiseState)
	{
		foreach (NoiseChunk chunk in noiseChunks)
		{
			float minValue = 0;
			float maxValue = 0;
			switch (noiseState)
			{
				case NoiseState.Increase:
					minValue = -value / (step * 2);
					maxValue = value / step;
					break;
				case NoiseState.Decrease:
					minValue = -value / step;
					maxValue = value / (step * 2);
					break;
				case NoiseState.Equal:
					minValue = -value / step;
					maxValue = value / step;
					break;
			}

			float newValue = Mathf.Clamp01(chunk.noise + Random.Range(minValue, maxValue));
			chunk.SetNoise(newValue);
		}
	}

	void MakeClear()
	{
		foreach (NoiseChunk chunk in noiseChunks)
		{
			chunk.SetNoise(0);
		}
	}
}
