// WorldTransform
using ClubPenguin.Net.Domain.Igloo;
using System;
using UnityEngine;

[Serializable]
public struct WorldTransform
{
	public Vector3 position;

	public ClubPenguin.Net.Domain.Igloo.Quaternion rotation;

	public Vector3 scale;

	public static WorldTransform FromTransform(Transform transform)
	{
		WorldTransform result = default(WorldTransform);
		result.position = transform.position;
		result.rotation.w = transform.rotation.w;
		result.rotation.x = transform.rotation.x;
		result.rotation.y = transform.rotation.y;
		result.rotation.z = transform.rotation.z;
		result.scale = transform.localScale;
		return result;
	}

	public override string ToString()
	{
		return $"Position: {position}, Rotation: {rotation}, Scale: {scale}";
	}
}
