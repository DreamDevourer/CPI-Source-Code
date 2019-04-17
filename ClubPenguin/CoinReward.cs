// CoinReward
using ClubPenguin;
using ClubPenguin.Net.Domain;
using LitJson;
using System;
using UnityEngine;

[Serializable]
public class CoinReward : IRewardable
{
	[SerializeField]
	private int coins;

	public int Coins => coins;

	public object Reward => coins;

	public string RewardType => "coins";

	public CoinReward()
	{
		coins = 0;
	}

	public CoinReward(int coins)
	{
		this.coins = coins;
	}

	public void FromJson(JsonData jsonData)
	{
		coins = (int)jsonData;
	}

	public void Add(IRewardable reward)
	{
		CoinReward coinReward = (CoinReward)reward;
		coins += coinReward.coins;
	}

	public bool IsEmpty()
	{
		return coins == 0;
	}
}
