// DonationResult
using ClubPenguin.Net.Domain;
using System;

[Serializable]
public class DonationResult
{
	public long cfcTotal;

	public int remainingCoinBalance;

	public RewardJsonReader reward;
}
