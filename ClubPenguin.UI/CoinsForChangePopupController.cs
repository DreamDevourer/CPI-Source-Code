// CoinsForChangePopupController
using ClubPenguin;
using ClubPenguin.Analytics;
using ClubPenguin.Core;
using ClubPenguin.Net;
using ClubPenguin.Net.Domain;
using ClubPenguin.Rewards;
using ClubPenguin.UI;
using DevonLocalization.Core;
using Disney.Kelowna.Common;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CoinsForChangePopupController : AnimatedPopup
{
	private enum CoinsForChangePopupState
	{
		Donate,
		MoreInfo,
		Thanks
	}

	private const string CoinsToken = "GlobalUI.Notification.Coins";

	private const string ThankYouButtonsId = "ThankYouButtons";

	public GameObject DonatePanel;

	public GameObject DonateButtonsPanel;

	public GameObject ThankYouTextPanel;

	public GameObject ThankYouButtonPanel;

	public GameObject MoreInfoPanel;

	public GameObject DefaultInfoPanel;

	public Text DonatedCoinsText;

	public GameObject[] DonateButtons;

	public GameObject[] NotEnoughDonateButtons;

	public int[] DonationAmounts;

	public GameObject LoadingOverlay;

	public CoinsForChangeCounter Counter;

	[LocalizationToken]
	public string RewardHeaderToken = "Loading.Ad.CFC.Title";

	public float RewardScreenDelay = 2f;

	private CoinsForChangePopupState currentState;

	private int lastDonationAmount;

	private CoinsForChangeStation coinsForChangeStation;

	private bool waitingForRewardScreen = false;

	private Reward rewardToShow;

	private EventDispatcher dispatcher;

	private void Start()
	{
		dispatcher = Service.Get<EventDispatcher>();
		setState(CoinsForChangePopupState.Donate);
		checkPlayerCoinCount();
	}

	private void OnDestroy()
	{
		CoroutineRunner.StopAllForOwner(this);
		if (waitingForRewardScreen && rewardToShow != null)
		{
			new ShowRewardPopup.Builder(DRewardPopup.RewardPopupType.generic, rewardToShow).setHeaderText(RewardHeaderToken).Build().Execute();
		}
	}

	public void Init(CoinsForChangeStation station, CoinsForChangeTracker tracker)
	{
		coinsForChangeStation = station;
		Counter.SetTracker(tracker);
	}

	public void DonateButtonPressed(int index)
	{
		LoadingOverlay.SetActive(value: true);
		dispatcher.AddListener<ScheduledEventServiceEvents.CFCDonationPosted>(onDonationPosted);
		Service.Get<INetworkServicesManager>().ScheduledEventService.PostCFCDonation(DonationAmounts[index]);
		DonatedCoinsText.text = string.Format(Service.Get<Localizer>().GetTokenTranslation("GlobalUI.Notification.Coins"), DonationAmounts[index]);
		lastDonationAmount = DonationAmounts[index];
		checkPlayerCoinCount();
	}

	private bool onDonationPosted(ScheduledEventServiceEvents.CFCDonationPosted evt)
	{
		dispatcher.RemoveListener<ScheduledEventServiceEvents.CFCDonationPosted>(onDonationPosted);
		Service.Get<CPDataEntityCollection>().GetComponent<CoinsData>(Service.Get<CPDataEntityCollection>().LocalPlayerHandle).Coins = evt.DonationResult.remainingCoinBalance;
		if (evt.DonationResult.reward != null)
		{
			dispatcher.DispatchEvent(new UIDisablerEvents.DisableUIElementGroup("ThankYouButtons"));
			CoroutineRunner.Start(showRewardPopup(evt.DonationResult.reward.ToReward(), RewardScreenDelay), this, "ShowCFCPopup");
		}
		checkPlayerCoinCount();
		setState(CoinsForChangePopupState.Thanks);
		LoadingOverlay.SetActive(value: false);
		coinsForChangeStation.OnCoinsDonated();
		Service.Get<EventDispatcher>().DispatchEvent(new HeadStatusEvents.ShowHeadStatus(TemporaryHeadStatusType.CFCDonation));
		Service.Get<ICPSwrveService>().Action("game.cfc", "donate", lastDonationAmount.ToString());
		return false;
	}

	private IEnumerator showRewardPopup(Reward reward, float delay)
	{
		waitingForRewardScreen = true;
		rewardToShow = reward;
		yield return new WaitForSeconds(delay);
		waitingForRewardScreen = false;
		base.gameObject.SetActive(value: false);
		new ShowRewardPopup.Builder(DRewardPopup.RewardPopupType.generic, reward).setHeaderText(RewardHeaderToken).Build().Execute();
		dispatcher.AddListener<RewardEvents.RewardPopupComplete>(onRewardPopupComplete);
	}

	private bool onRewardPopupComplete(RewardEvents.RewardPopupComplete evt)
	{
		dispatcher.RemoveListener<RewardEvents.RewardPopupComplete>(onRewardPopupComplete);
		base.gameObject.SetActive(value: true);
		dispatcher.DispatchEvent(new UIDisablerEvents.EnableUIElementGroup("ThankYouButtons"));
		return false;
	}

	public void LearnMoreButtonPressed()
	{
		setState(CoinsForChangePopupState.MoreInfo);
	}

	public void LeanMoreOkButtonPressed()
	{
		setState(CoinsForChangePopupState.Donate);
	}

	public void DonateMoreButtonPressed()
	{
		setState(CoinsForChangePopupState.Donate);
	}

	private void setState(CoinsForChangePopupState newState)
	{
		if (newState != currentState)
		{
			switch (newState)
			{
			case CoinsForChangePopupState.Donate:
				DonatePanel.SetActive(value: true);
				DonateButtonsPanel.SetActive(value: true);
				DefaultInfoPanel.SetActive(value: true);
				ThankYouTextPanel.SetActive(value: false);
				ThankYouButtonPanel.SetActive(value: false);
				MoreInfoPanel.SetActive(value: false);
				break;
			case CoinsForChangePopupState.MoreInfo:
				DefaultInfoPanel.SetActive(value: false);
				MoreInfoPanel.SetActive(value: true);
				break;
			case CoinsForChangePopupState.Thanks:
				DonatePanel.SetActive(value: false);
				DonateButtonsPanel.SetActive(value: false);
				ThankYouTextPanel.SetActive(value: true);
				ThankYouButtonPanel.SetActive(value: true);
				break;
			}
			currentState = newState;
		}
	}

	private void checkPlayerCoinCount()
	{
		int coins = Service.Get<CPDataEntityCollection>().GetComponent<CoinsData>(Service.Get<CPDataEntityCollection>().LocalPlayerHandle).Coins;
		for (int i = 0; i < DonationAmounts.Length; i++)
		{
			DonateButtons[i].SetActive(coins >= DonationAmounts[i]);
			NotEnoughDonateButtons[i].SetActive(coins < DonationAmounts[i]);
		}
	}
}
