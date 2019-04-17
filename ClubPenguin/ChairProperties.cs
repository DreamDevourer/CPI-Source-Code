// ChairProperties
using ClubPenguin;
using System;
using UnityEngine;

public class ChairProperties : MonoBehaviour
{
	[Serializable]
	public struct Properties
	{
		public int EnterSitAnimIndex;

		public int SitAnimIndex;

		public Vector3 ChestBoneRotation;
	}

	public Properties Fields = new Properties
	{
		EnterSitAnimIndex = 0,
		SitAnimIndex = 0,
		ChestBoneRotation = Vector3.zero
	};
}
