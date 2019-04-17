// TubeRaceLeaderboardItem
using ClubPenguin;
using ClubPenguin.Core;
using Disney.Kelowna.Common.DataModel;
using Disney.MobileNetwork;
using UnityEngine;
using UnityEngine.UI;

public class TubeRaceLeaderboardItem : MonoBehaviour
{
	private const string DEFAULT_PLAYER_NAME = "";

	public Text PlayerNameText;

	public Text ScoreText;

	private CPDataEntityCollection dataEntityCollection;

	private void Awake()
	{
		dataEntityCollection = Service.Get<CPDataEntityCollection>();
	}

	public void SetData(long sessionId, int score)
	{
		string playerName = getPlayerName(sessionId);
		if (playerName != "")
		{
			PlayerNameText.text = playerName;
			ScoreText.text = score.ToString();
			base.gameObject.SetActive(value: true);
		}
		else
		{
			base.gameObject.SetActive(value: false);
		}
	}

	private string getPlayerName(long sessionId)
	{
		string result = "";
		if (dataEntityCollection.TryFindEntity<SessionIdData, long>(sessionId, out DataEntityHandle dataEntityHandle) && dataEntityCollection.TryGetComponent(dataEntityHandle, out DisplayNameData component))
		{
			result = component.DisplayName;
		}
		return result;
	}
}
