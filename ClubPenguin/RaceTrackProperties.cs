// RaceTrackProperties
using ClubPenguin;
using System;
using UnityEngine;

public class RaceTrackProperties : MonoBehaviour
{
	[Serializable]
	public struct Properties
	{
		public float Drag;

		public float MaxSpeed;
	}

	public Properties properties = new Properties
	{
		Drag = 0.25f,
		MaxSpeed = 12f
	};
}
