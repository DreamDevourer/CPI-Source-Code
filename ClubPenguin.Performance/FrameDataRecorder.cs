// FrameDataRecorder
using ClubPenguin.Performance;
using System;
using UnityEngine;

public class FrameDataRecorder : MonoBehaviour
{
	public int FrameSampleSize = 300;

	public float TargetFPS = 30f;

	private int prevFrameSampleSize = 100;

	private int currentIndex = 0;

	private float[] deltaTimes;

	private float minDeltaTime = 3.40282347E+38f;

	private float maxDeltaTime = -3.40282347E+38f;

	public event Action<FrameData> FrameDataUpdated;

	private void Awake()
	{
		deltaTimes = new float[FrameSampleSize];
		prevFrameSampleSize = FrameSampleSize;
		FrameDataRecorder[] array = UnityEngine.Object.FindObjectsOfType<FrameDataRecorder>();
		if (array.Length > 1)
		{
			throw new Exception("Scene should only contain 1 FrameDataRecorder");
		}
		base.gameObject.name = "FrameDataRecorder";
	}

	private void Update()
	{
		if (prevFrameSampleSize != FrameSampleSize)
		{
			if (FrameSampleSize <= 0)
			{
				FrameSampleSize = 100;
			}
			deltaTimes = new float[FrameSampleSize];
			currentIndex = 0;
			prevFrameSampleSize = FrameSampleSize;
			minDeltaTime = 3.40282347E+38f;
			maxDeltaTime = -3.40282347E+38f;
		}
		float deltaTime = Time.deltaTime;
		deltaTimes[currentIndex] = deltaTime;
		if (deltaTime < minDeltaTime)
		{
			minDeltaTime = deltaTime;
		}
		if (deltaTime > maxDeltaTime)
		{
			maxDeltaTime = deltaTime;
		}
		currentIndex++;
		if (currentIndex == FrameSampleSize)
		{
			dispatchData();
			currentIndex = 0;
			minDeltaTime = 3.40282347E+38f;
			maxDeltaTime = -3.40282347E+38f;
		}
	}

	private void dispatchData()
	{
		float num = 0f;
		for (int i = 0; i < deltaTimes.Length; i++)
		{
			num += deltaTimes[i];
		}
		num /= (float)deltaTimes.Length;
		float medianFPS = 0f;
		FrameData obj = default(FrameData);
		obj.AverageFPS = 1000f / num;
		obj.MedianFPS = medianFPS;
		obj.MinFPS = 1000f / minDeltaTime;
		obj.MaxFPS = 1000f / maxDeltaTime;
		obj.NumFramesSampled = FrameSampleSize;
		obj.TargetFPS = TargetFPS;
		if (this.FrameDataUpdated != null)
		{
			this.FrameDataUpdated(obj);
		}
	}
}
