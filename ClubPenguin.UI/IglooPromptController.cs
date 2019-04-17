// IglooPromptController
using ClubPenguin.UI;
using UnityEngine;

public class IglooPromptController : PromptController
{
	public GameObject closeButton;

	protected override GameObject createButtonObject(DPrompt data, int buttonIndex, DPrompt.ButtonFlags flag, ref string i18nText)
	{
		if (flag == DPrompt.ButtonFlags.CLOSE)
		{
			closeButton.SetActive(value: true);
			return closeButton;
		}
		return base.createButtonObject(data, buttonIndex, flag, ref i18nText);
	}
}
