// FriendsListFullTooltipButton
using ClubPenguin.TutorialUI;
using DevonLocalization.Core;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using Game.UI.PlayerCard.Scripts;
using UnityEngine;

public class FriendsListFullTooltipButton : TutorialTooltipButton
{
	public string localPlayerListFullToken;

	public string remotePlayerListFullToken;

	private string currentToken = "";

	public void SetIsLocalPlayer(bool isLocalPlayer)
	{
		currentToken = (isLocalPlayer ? localPlayerListFullToken : remotePlayerListFullToken);
	}

	protected override void onButtonClick()
	{
		GameObject gameObject = Object.Instantiate(TooltipPrefab);
		gameObject.GetComponent<FriendsListFullTooltipLabel>().label.text = Service.Get<Localizer>().GetTokenTranslation(currentToken);
		Service.Get<EventDispatcher>().DispatchEvent(new TutorialUIEvents.ShowTooltip(gameObject, GetComponent<RectTransform>(), Offset, FullscreenClose));
	}
}
