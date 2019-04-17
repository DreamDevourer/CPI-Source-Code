// LocomotionControllerData
using UnityEngine;

public class LocomotionControllerData : ScriptableObject
{
	private bool isDestroyed = false;

	public bool IsDestroyed => isDestroyed;

	public void OnDestroy()
	{
		isDestroyed = true;
	}
}
