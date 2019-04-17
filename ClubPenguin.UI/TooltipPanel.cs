// TooltipPanel
using UnityEngine;

public class TooltipPanel : MonoBehaviour
{
	private bool isShowing;

	private void Update()
	{
		if (isShowing && Input.GetMouseButtonDown(0))
		{
			isShowing = false;
			base.gameObject.SetActive(isShowing);
		}
	}

	public void ShowTooltip()
	{
		if (!isShowing)
		{
			isShowing = true;
			base.gameObject.SetActive(isShowing);
		}
	}
}
