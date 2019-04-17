// CandleFlickerData
using System;
using UnityEngine;

[Serializable]
public class CandleFlickerData
{
	public Material PumpkinMaterial;

	public Color BaseColor = new Color(1f, 1f, 0f);

	public AnimationCurve flickerCurve;

	public float AnimTime = 1f;

	public float AnimStep = 0.01f;
}
