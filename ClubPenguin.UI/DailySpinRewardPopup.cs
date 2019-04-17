// DailySpinRewardPopup
using ClubPenguin;
using ClubPenguin.Net.Domain;
using ClubPenguin.NPC;
using DevonLocalization.Core;
using Disney.Kelowna.Common;
using Disney.MobileNetwork;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DailySpinRewardPopup : MonoBehaviour
{
	private enum CoinsXpSelectorValues
	{
		Xp,
		Coins,
		PartyBlaster,
		Respin
	}

	private enum XpStarSelectorValues
	{
		AAXp,
		RHXp,
		RKXp,
		DJXp
	}

	private const string COINS_TEXT_TOKEN = "GlobalUI.Notification.Coins";

	private const string RESPIN_TEXT_TOKEN = "Cellphone.DailySpin.Rewards.Respin";

	private const string PARTY_BLASTER_TEXT_TOKEN = "Prop_Super_Party_Blaster";

	public Action RewardPopupComplete;

	public SpriteSelector RewardIconImage;

	public Text CoinsText;

	public Text XpText;

	public SpriteSelector XPIconImage;

	public GameObject OKButton;

	public GameObject RespinButton;

	public GameObject RewardScreen;

	public GameObject PunchScreen;

	public float CloseTime = 3f;

	private Localizer localizer;

	private void OnDisable()
	{
		CoroutineRunner.StopAllForOwner(this);
	}

	public void ShowReward(Reward spinReward, bool isRespin)
	{
		localizer = Service.Get<Localizer>();
		Reset();
		base.gameObject.SetActive(value: true);
		MascotXPReward rewardable2;
		if (spinReward.TryGetValue(out CoinReward rewardable) && rewardable.Coins > 0)
		{
			CoinsText.gameObject.SetActive(value: true);
			if (isRespin)
			{
				OKButton.SetActive(value: false);
				RespinButton.SetActive(value: true);
				CoinsText.text = string.Format(localizer.GetTokenTranslation("Cellphone.DailySpin.Rewards.Respin"), rewardable.Coins);
				RewardIconImage.SelectSprite(3);
			}
			else
			{
				CoinsText.text = string.Format(localizer.GetTokenTranslation("GlobalUI.Notification.Coins"), rewardable.Coins);
				RewardIconImage.SelectSprite(1);
			}
		}
		else if (spinReward.TryGetValue(out rewardable2))
		{
			using (Dictionary<string, int>.Enumerator enumerator = rewardable2.XP.GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					KeyValuePair<string, int> current = enumerator.Current;
					int index = 0;
					RewardIconImage.SelectSprite(0);
					if (current.Key == "AuntArctic")
					{
						index = 0;
					}
					if (current.Key == "Rockhopper")
					{
						index = 1;
					}
					if (current.Key == "Rookie")
					{
						index = 2;
					}
					if (current.Key == "DJCadence")
					{
						index = 3;
					}
					XPIconImage.SelectSprite(index);
					XPIconImage.gameObject.SetActive(value: true);
					XpText.text = current.Value.ToString();
					XpText.gameObject.SetActive(value: true);
				}
			}
		}
		else
		{
			RewardIconImage.SelectSprite(2);
			CoinsText.text = localizer.GetTokenTranslation("Prop_Super_Party_Blaster");
			CoinsText.gameObject.SetActive(value: true);
		}
	}

	private void Reset()
	{
		CoinsText.gameObject.SetActive(value: false);
		XpText.gameObject.SetActive(value: false);
		OKButton.SetActive(value: true);
		RespinButton.SetActive(value: false);
		XPIconImage.gameObject.SetActive(value: false);
		RewardScreen.SetActive(value: true);
		PunchScreen.SetActive(value: false);
	}

	public void OnOkButtonPressed()
	{
		RewardScreen.SetActive(value: false);
		PunchScreen.SetActive(value: true);
		CoroutineRunner.Start(closeAfterDelay(), this, "DailySpinRewardPopupCloseDelay");
	}

	private IEnumerator closeAfterDelay()
	{
		yield return new WaitForSeconds(CloseTime);
		base.gameObject.SetActive(value: false);
		if (RewardPopupComplete != null)
		{
			RewardPopupComplete();
		}
	}
}
