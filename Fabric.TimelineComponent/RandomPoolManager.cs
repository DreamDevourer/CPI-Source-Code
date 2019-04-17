// RandomPoolManager
using Fabric;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("")]
public class RandomPoolManager : Fabric.Component
{
	[HideInInspector]
	[SerializeField]
	public Dictionary<string, RandomComponent> _definitionsTable = new Dictionary<string, RandomComponent>();

	[HideInInspector]
	[SerializeField]
	public string projectName;
}
