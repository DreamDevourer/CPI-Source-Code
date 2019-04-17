// PartyGameEndGamePlayerItem
using ClubPenguin;
using ClubPenguin.Core;
using ClubPenguin.Game.PartyGames;
using Disney.Kelowna.Common.DataModel;
using Disney.MobileNetwork;
using UnityEngine;
using UnityEngine.UI;

public class PartyGameEndGamePlayerItem : MonoBehaviour
{
	public Text PlayerNameText;

	public Text ScoreText;

	public SpriteSelector PlayerIcon;

	public GameObject TrophyIcon;

	public Animator TrophyAnimator;

	public GameObject SelectedBG;

	public Image ScoreBG;

	public GameObject FirstPlaceEffects;

	private readonly Color fadeColor = new Color(1f, 1f, 1f, 0.55f);

	public void SetPlayerData(PartyGameEndGamePlayerData playerData)
	{
		DataEntityHandle handle = Service.Get<CPDataEntityCollection>().FindEntity<SessionIdData, long>(playerData.PlayerId);
		if (Service.Get<CPDataEntityCollection>().TryGetComponent(handle, out DisplayNameData component))
		{
			PlayerNameText.text = component.DisplayName;
		}
		PlayerIcon.SelectSprite(playerData.PlayerNum);
		SelectedBG.GetComponent<Image>().enabled = playerData.IsLocalPlayer;
		TrophyIcon.SetActive(playerData.Placement == 0);
		TrophyAnimator.enabled = (playerData.IsLocalPlayer && playerData.Placement == 0);
		if (playerData.HasScore)
		{
			ScoreText.text = playerData.Score.ToString();
		}
		if (FirstPlaceEffects != null)
		{
			FirstPlaceEffects.SetActive(playerData.IsLocalPlayer && playerData.Placement == 0);
		}
		if (playerData.Placement == -1)
		{
			if (playerData.HasScore)
			{
				ScoreText.gameObject.SetActive(value: false);
				ScoreBG.color = fadeColor;
			}
			PlayerIcon.GetComponent<Image>().color = fadeColor;
		}
	}
}
