// Quaternion
using ClubPenguin.Net.Domain.Scene;
using UnityEngine;

public struct Quaternion
{
	public float x;

	public float y;

	public float z;

	public float w;

	public static ClubPenguin.Net.Domain.Scene.Quaternion FromUnityQuaternion(UnityEngine.Quaternion uq)
	{
		ClubPenguin.Net.Domain.Scene.Quaternion result = default(ClubPenguin.Net.Domain.Scene.Quaternion);
		result.x = uq.x;
		result.y = uq.y;
		result.z = uq.z;
		result.w = uq.w;
		return result;
	}

	public static UnityEngine.Quaternion ToUnityQuaternion(ClubPenguin.Net.Domain.Scene.Quaternion q)
	{
		UnityEngine.Quaternion result = default(UnityEngine.Quaternion);
		result.w = q.w;
		result.x = q.x;
		result.y = q.y;
		result.z = q.z;
		return result;
	}
}
