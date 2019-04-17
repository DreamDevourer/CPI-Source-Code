// TriggerEditorView
using UnityEngine;

[DisallowMultipleComponent]
public class TriggerEditorView : MonoBehaviour
{
	[HideInInspector]
	public Renderer Renderer;

	private void Awake()
	{
		Object.Destroy(this);
	}
}
