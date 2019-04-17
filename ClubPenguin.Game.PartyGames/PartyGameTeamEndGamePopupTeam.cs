// PartyGameTeamEndGamePopupTeam
using ClubPenguin;
using ClubPenguin.Game.PartyGames;
using DevonLocalization.Core;
using Disney.MobileNetwork;
using UnityEngine;
using UnityEngine.UI;

public class PartyGameTeamEndGamePopupTeam : MonoBehaviour
{
	public Text TeamNameText;

	public Text TeamScoreText;

	public GameObject TeamScorePanel;

	public GameObject WinPanel;

	public TintSelector BackgroundTintSelector;

	public SpriteSelector TeamIconSpriteSelector;

	public void SetTeamData(PartyGameTeamEndGamePopupData.PartyGameTeamEndGamePopupTeamData teamData)
	{
		TeamNameText.text = Service.Get<Localizer>().GetTokenTranslation(teamData.TeamNameToken);
		if (teamData.IsShowingScore)
		{
			TeamScorePanel.SetActive(value: true);
			TeamScoreText.text = teamData.Score.ToString();
		}
		else if (TeamScorePanel != null)
		{
			TeamScorePanel.SetActive(value: false);
		}
		WinPanel.SetActive(teamData.IsWinningTeam);
		if (teamData.IsLocalPlayersTeam)
		{
			BackgroundTintSelector.SelectColor(teamData.TeamThemeId);
		}
		else
		{
			BackgroundTintSelector.GetComponent<Image>().enabled = false;
		}
		TeamIconSpriteSelector.SelectSprite(teamData.TeamThemeId);
	}
}
