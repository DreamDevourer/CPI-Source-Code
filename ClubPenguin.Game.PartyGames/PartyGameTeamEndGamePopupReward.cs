// PartyGameTeamEndGamePopupReward
using ClubPenguin;
using ClubPenguin.Net.Domain;
using ClubPenguin.NPC;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartyGameTeamEndGamePopupReward : MonoBehaviour
{
	public Text CoinText;

	public Text XpText;

	public GameObject XpPanel;

	public GameObject CoinPanel;

	public void SetReward(Reward reward)
	{
		displayCoins(reward);
		displayXP(reward);
	}

	private void displayCoins(Reward reward)
	{
		if (reward.TryGetValue(out CoinReward rewardable) && !rewardable.IsEmpty())
		{
			CoinPanel.SetActive(value: true);
			CoinText.text = rewardable.Coins.ToString();
		}
		else
		{
			CoinPanel.SetActive(value: false);
		}
	}

	private void displayXP(Reward reward)
	{
		if (reward.TryGetValue(out MascotXPReward rewardable))
		{
			if (rewardable.XP.Count > 1)
			{
			}
			Dictionary<string, int>.Enumerator enumerator = rewardable.XP.GetEnumerator();
			enumerator.MoveNext();
			KeyValuePair<string, int> current = enumerator.Current;
			XpPanel.SetActive(value: true);
			XpText.text = current.Value.ToString();
		}
		else
		{
			XpPanel.SetActive(value: false);
		}
	}
}
