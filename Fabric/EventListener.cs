// EventListener
using Fabric;
using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Fabric/Events/Listener")]
public class EventListener : MonoBehaviour
{
	[SerializeField]
	[HideInInspector]
	public string _eventName = "_UnSet_";

	[HideInInspector]
	[SerializeField]
	public int _eventID;

	[SerializeField]
	[HideInInspector]
	public bool _overrideEventTriggerAction;

	[SerializeField]
	[HideInInspector]
	public OverrideParameters _overrideParameters;

	private void OnDestroy()
	{
		if (FabricManager._componentPreviewerUpdateIsActive)
		{
			Fabric.Component component = base.gameObject.GetComponent<Fabric.Component>();
			if (component != null)
			{
				component.UnregisterEventListeners();
			}
		}
	}
}
