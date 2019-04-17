// ComponentInstance
using Fabric;
using UnityEngine;

public class ComponentInstance
{
	public Vector3 _randomisePosition;

	public GameObject _parentGameObject
	{
		get;
		set;
	}

	public GameObject _componentGameObject
	{
		get;
		set;
	}

	public Fabric.Component _componentInstanceHolder
	{
		get;
		set;
	}

	public Fabric.Component _instance
	{
		get;
		set;
	}

	public Transform _transform
	{
		get;
		set;
	}

	public float _triggerTime
	{
		get;
		set;
	}
}
