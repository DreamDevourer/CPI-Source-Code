// MainNavButtonDisabler
using ClubPenguin.UI;
using UnityEngine;

[RequireComponent(typeof(MainNavButton))]
public class MainNavButtonDisabler : UIElementDisabler
{
	public override void DisableElement(bool hide)
	{
		changeVisibility(!hide);
		GetComponent<MainNavButton>().SetButtonEnabled(enabled: false);
		if (Breadcrumb != null)
		{
			Breadcrumb.SetActive(value: false);
		}
		QuestButtonSpriteSelector component = base.gameObject.GetComponent<QuestButtonSpriteSelector>();
		if (component != null)
		{
			component.OnButtonDisabled();
		}
	}

	public override void EnableElement()
	{
		changeVisibility(show: true);
		GetComponent<MainNavButton>().SetButtonEnabled(enabled: true);
		if (Breadcrumb != null)
		{
			Breadcrumb.SetActive(value: true);
		}
		QuestButtonSpriteSelector component = base.gameObject.GetComponent<QuestButtonSpriteSelector>();
		if (component != null)
		{
			component.OnButtonEnabled();
		}
	}
}
