// SetMainNavTitleTextOnStart
using ClubPenguin.Core;
using ClubPenguin.UI;
using DevonLocalization.Core;
using Disney.MobileNetwork;
using UnityEngine;

public class SetMainNavTitleTextOnStart : MonoBehaviour
{
	private const string MAIN_NAV_GO_NAME = "MainNavBar";

	public string TitleTextToken;

	public void Start()
	{
		string tokenTranslation = Service.Get<Localizer>().GetTokenTranslation(TitleTextToken);
		MainNavStateHandler componentInChildren = GameObject.FindWithTag(UIConstants.Tags.UI_Tray_Root).GetComponentInChildren<MainNavStateHandler>();
		componentInChildren.SetTitleText(tokenTranslation);
	}
}
