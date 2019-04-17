// DSPParameterData
using Fabric;
using System;
using UnityEngine;

[Serializable]
public class DSPParameterData
{
	[SerializeField]
	public DSPType _dspType;

	[SerializeField]
	public string _parameter = "";

	[SerializeField]
	public float _value;

	[SerializeField]
	public float _time;

	[SerializeField]
	public float _curve = 0.5f;
}
