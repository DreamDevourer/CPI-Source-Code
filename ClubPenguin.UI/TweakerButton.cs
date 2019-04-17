// TweakerButton
using Disney.MobileNetwork;
using Tweaker.UI;
using UnityEngine;

public class TweakerButton : MonoBehaviour
{
	public void OnTweakerButton()
	{
		TweakerConsoleController tweakerConsoleController = Service.Get<TweakerConsoleController>();
		if (!tweakerConsoleController.gameObject.activeSelf)
		{
			tweakerConsoleController.ShowConsole();
		}
	}
}
