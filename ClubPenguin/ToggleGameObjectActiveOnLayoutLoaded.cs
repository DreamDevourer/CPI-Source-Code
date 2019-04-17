// ToggleGameObjectActiveOnLayoutLoaded
using ClubPenguin.Core;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using UnityEngine;

public class ToggleGameObjectActiveOnLayoutLoaded : MonoBehaviour
{
	public void Start()
	{
		Service.Get<EventDispatcher>().AddListener<SceneTransitionEvents.LayoutGameObjectsLoaded>(onLayoutGameObjectsLoaded);
	}

	private bool onLayoutGameObjectsLoaded(SceneTransitionEvents.LayoutGameObjectsLoaded evt)
	{
		base.gameObject.SetActive(value: false);
		base.gameObject.SetActive(value: true);
		return false;
	}

	public void OnDestroy()
	{
		Service.Get<EventDispatcher>().RemoveListener<SceneTransitionEvents.LayoutGameObjectsLoaded>(onLayoutGameObjectsLoaded);
	}
}
