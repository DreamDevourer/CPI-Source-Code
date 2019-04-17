// IglooSlotsReward
using ClubPenguin.Net.Domain;
using ClubPenguin.Rewards;
using LitJson;
using System;
using UnityEngine;

[Serializable]
public class IglooSlotsReward : IRewardable
{
	[SerializeField]
	private int iglooSlots;

	public int IglooSlots => iglooSlots;

	public object Reward => iglooSlots;

	public string RewardType => "iglooSlots";

	public IglooSlotsReward()
	{
		iglooSlots = 0;
	}

	public IglooSlotsReward(int iglooSlots)
	{
		this.iglooSlots = iglooSlots;
	}

	public void FromJson(JsonData jsonData)
	{
		iglooSlots = (int)jsonData;
	}

	public void Add(IRewardable reward)
	{
		IglooSlotsReward iglooSlotsReward = (IglooSlotsReward)reward;
		iglooSlots += iglooSlotsReward.iglooSlots;
	}

	public bool IsEmpty()
	{
		return iglooSlots == 0;
	}
}
