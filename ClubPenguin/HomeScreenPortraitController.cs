// HomeScreenPortraitController
using ClubPenguin;
using ClubPenguin.Core;
using ClubPenguin.Input;
using ClubPenguin.Net;
using ClubPenguin.UI;
using Disney.Kelowna.Common;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HomeScreenPortraitController : HomeScreenController
{
	[Header("Buttons")]
	public Button PlayButton;

	public GameObject PlayButtonSpinner;

	public Button ContinuePlayButton;

	public GameObject ContinuePlayButtonSpinner;

	public Button ReplayIntroButton;

	public Button LogoutButton;

	public Text LogoutButtonText;

	public GameObject LogoutButtonSpinner;

	private BundlePrecacheManager bundlePrecacheManager;

	public LoadingBar PrecacheLoadingBar;

	private float PrecacheTime = 180f;

	private float precacheTimer = 0f;

	protected override void Awake()
	{
		base.Awake();
		bundlePrecacheManager = Service.Get<BundlePrecacheManager>();
	}

	protected override void OnEnable()
	{
		base.OnEnable();
		PlayButton.GetComponent<ButtonClickListener>().OnClick.AddListener(onPlayClicked);
		ContinuePlayButton.onClick.AddListener(onContinueClicked);
		ReplayIntroButton.onClick.AddListener(onReplayIntroClicked);
		LogoutButton.onClick.AddListener(onLogoutClicked);
	}

	protected override void OnDisable()
	{
		base.OnDisable();
		PlayButton.GetComponent<ButtonClickListener>().OnClick.RemoveListener(onPlayClicked);
		ContinuePlayButton.onClick.RemoveListener(onContinueClicked);
		ReplayIntroButton.onClick.RemoveListener(onReplayIntroClicked);
		LogoutButton.onClick.RemoveListener(onLogoutClicked);
	}

	protected override void firstTimeSetup()
	{
		StartCoroutine(precacheBundles());
	}

	private void Update()
	{
		if (PrecacheLoadingBar.gameObject.activeInHierarchy)
		{
			precacheTimer += Time.deltaTime;
			float a = Mathf.Max(precacheTimer / PrecacheTime, bundlePrecacheManager.CompleteRatio);
			PrecacheLoadingBar.SetCompletion(Mathf.Min(a, 1f));
		}
	}

	public void ClickPlay()
	{
		onPlayClicked(ButtonClickListener.ClickType.UI);
	}

	private void onPlayClicked(ButtonClickListener.ClickType interactedType)
	{
		if (Service.Get<ApplicationService>().RequiresUpdate)
		{
			ForcedUpgrade.OpenForcedUpgradePrompt();
			return;
		}
		PlayButtonSpinner.SetActive(value: true);
		PlayButton.interactable = false;
		Service.Get<EventDispatcher>().AddListener<AccountSystemEvents.AccountSystemEnded>(resetPlayButton);
		gameStateController.EnterGame();
	}

	private bool resetPlayButton(AccountSystemEvents.AccountSystemEnded evt)
	{
		Service.Get<EventDispatcher>().RemoveListener<AccountSystemEvents.AccountSystemEnded>(resetPlayButton);
		PlayButtonSpinner.SetActive(value: false);
		PlayButton.interactable = true;
		setupScreen();
		return false;
	}

	private void onContinueClicked()
	{
		Service.Get<EventDispatcher>().AddListener<AccountSystemEvents.AccountSystemEnded>(resetContinueButton);
		ContinuePlayButtonSpinner.SetActive(value: true);
		ContinuePlayButton.interactable = false;
		gameStateController.ShowAccountSystem("enterworld");
	}

	private bool resetContinueButton(AccountSystemEvents.AccountSystemEnded evt)
	{
		Service.Get<EventDispatcher>().RemoveListener<AccountSystemEvents.AccountSystemEnded>(resetContinueButton);
		ContinuePlayButtonSpinner.SetActive(value: false);
		ContinuePlayButton.interactable = true;
		setupScreen();
		return false;
	}

	private void onReplayIntroClicked()
	{
		gameStateController.PlayIntroVideo();
	}

	private void onLogoutClicked()
	{
		Service.Get<SessionManager>().Logout();
		Service.Get<GameStateController>().ResetStateMachine();
		LogoutButtonSpinner.SetActive(value: true);
		LogoutButtonText.gameObject.SetActive(value: false);
		LogoutButton.interactable = false;
	}

	private IEnumerator precacheBundles()
	{
		precacheTimer = 0f;
		PlayButton.gameObject.SetActive(value: false);
		ContinuePlayButton.gameObject.SetActive(value: false);
		ReplayIntroButton.gameObject.SetActive(value: false);
		LogoutButton.gameObject.SetActive(value: false);
		MembershipButton.gameObject.SetActive(value: false);
		SettingsButton.gameObject.SetActive(value: false);
		PrecacheLoadingBar.gameObject.SetActive(value: true);
		bundlePrecacheManager.StartCaching(precacheComplete);
		PrecacheTime = (float)(double)bundlePrecacheManager.Config.BundlePrecacheSeconds;
		yield return new WaitForSeconds(PrecacheTime);
		precacheComplete();
	}

	private void precacheComplete()
	{
		if (PrecacheLoadingBar.gameObject.activeInHierarchy)
		{
			bundlePrecacheManager.MoveToBackground();
			PrecacheLoadingBar.gameObject.SetActive(value: false);
			setupScreen();
		}
	}

	protected override void disableAllButtons()
	{
		base.disableAllButtons();
		PlayButton.interactable = false;
		ContinuePlayButton.interactable = false;
		ReplayIntroButton.interactable = false;
		LogoutButton.interactable = false;
	}

	protected override void showPlayFlow()
	{
		base.showPlayFlow();
		PlayButton.gameObject.SetActive(value: true);
		ReplayIntroButton.gameObject.SetActive(value: true);
		ContinuePlayButton.gameObject.SetActive(value: false);
		LogoutButton.gameObject.SetActive(value: false);
	}

	protected override void showContinueFlow()
	{
		base.showContinueFlow();
		PlayButton.gameObject.SetActive(value: false);
		ContinuePlayButton.gameObject.SetActive(value: true);
		ReplayIntroButton.gameObject.SetActive(value: true);
		LogoutButton.gameObject.SetActive(value: true);
		if (Service.Get<CPDataEntityCollection>().IsLocalPlayerMember())
		{
			MembershipButton.gameObject.SetActive(value: false);
		}
	}

	protected override void Destroy()
	{
		base.Destroy();
		Service.Get<EventDispatcher>().RemoveListener<AccountSystemEvents.AccountSystemEnded>(resetPlayButton);
	}
}
