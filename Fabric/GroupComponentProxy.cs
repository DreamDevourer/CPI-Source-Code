// GroupComponentProxy
using Fabric;
using System;
using UnityEngine;

[AddComponentMenu("")]
public class GroupComponentProxy : MonoBehaviour
{
	[NonSerialized]
	public GroupComponent _groupComponent;

	[NonSerialized]
	public int _registeredWithMainRefCount;
}
