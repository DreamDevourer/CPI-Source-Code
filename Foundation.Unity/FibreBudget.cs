// FibreBudget
using Foundation.Unity;
using System;
using UnityEngine;

[CreateAssetMenu]
public class FibreBudget : ScriptableObject
{
	[Serializable]
	public struct TimeSlice
	{
		public string Name;

		public float DurationMs;
	}

	public TimeSlice[] TimeSlices;
}
