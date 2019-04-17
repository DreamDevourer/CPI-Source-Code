// DecorationLayout
using ClubPenguin.Net.Domain.Decoration;
using ClubPenguin.Net.Domain.Scene;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct DecorationLayout
{
	public struct Id
	{
		public string name;

		public string parent;
	}

	public Id id;

	public DecorationType type;

	public long definitionId;

	public Vector3 position;

	public ClubPenguin.Net.Domain.Scene.Quaternion rotation;

	public float scale;

	public Vector3 normal;

	public Dictionary<string, string> customProperties;
}
