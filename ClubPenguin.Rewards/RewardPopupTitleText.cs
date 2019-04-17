// RewardPopupTitleText
using ClubPenguin.Rewards;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class RewardPopupTitleText : MonoBehaviour
{
	private void Start()
	{
		setTitleText();
	}

	private void setTitleText()
	{
		string popupTitle = GetComponentInParent<RewardPopupController>().PopupTitle;
		if (!string.IsNullOrEmpty(popupTitle))
		{
			GetComponent<Text>().text = popupTitle;
		}
	}
}
