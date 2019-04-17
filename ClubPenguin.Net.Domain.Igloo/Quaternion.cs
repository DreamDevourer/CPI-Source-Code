// Quaternion
using UnityEngine;

public struct Quaternion
{
	public float x;

	public float y;

	public float z;

	public float w;

	public Quaternion ToUnityQaternion()
	{
		Quaternion result = default(Quaternion);
		result.w = w;
		result.x = x;
		result.y = y;
		result.z = z;
		return result;
	}
}
