// ScreenContainerBGToggler
using ClubPenguin.UI;
using UnityEngine;

public class ScreenContainerBGToggler : MonoBehaviour
{
	private GameObject bg;

	private ScreenContainerStateHandler screenContainerStateHandler;

	private void Start()
	{
		screenContainerStateHandler = GetComponentInParent<ScreenContainerStateHandler>();
		bg = screenContainerStateHandler.GetComponentInChildren<ScreenContainerBG>(includeInactive: true).gameObject;
		bg.gameObject.SetActive(value: false);
	}

	private void OnDisable()
	{
		if (!bg.gameObject.IsDestroyed() && screenContainerStateHandler.ShowScreenContainerBG)
		{
			bg.gameObject.SetActive(value: true);
		}
	}
}
