// SurfaceSwimProperties
using ClubPenguin.Locomotion;
using UnityEngine;

public class SurfaceSwimProperties : MonoBehaviour
{
	public enum VolumeType
	{
		SurfaceSwimming,
		Diving
	}

	public VolumeType Type = VolumeType.SurfaceSwimming;

	public float VisibleSurfaceHeight;

	public float SinkOffset;

	public bool SpecifyValuesInLocalSpace;

	public Transform ObjectOrigin;
}
