// TransitionData
using System;
using UnityEngine;

[Serializable]
public class TransitionData
{
	[SerializeField]
	public string _startEvent = "";

	[SerializeField]
	public double _scheduleStart;

	[SerializeField]
	public string _stopEvent = "";

	[SerializeField]
	public double _scheduleStop;
}
