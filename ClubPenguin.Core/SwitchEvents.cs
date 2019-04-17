// SwitchEvents
using UnityEngine;

public static class SwitchEvents
{
	public struct SwitchChange
	{
		public readonly Transform Owner;

		public readonly bool Value;

		public SwitchChange(Transform owner, bool value)
		{
			Owner = owner;
			Value = value;
		}
	}
}
