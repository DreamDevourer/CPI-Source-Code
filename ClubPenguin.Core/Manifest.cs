// Manifest
using System;
using UnityEngine;

[Serializable]
public class Manifest : ScriptableObject
{
	public ScriptableObject[] Assets;

	public void OnValidate()
	{
		ScriptableObject[] assets = Assets;
		foreach (ScriptableObject scriptableObject in assets)
		{
		}
	}
}
