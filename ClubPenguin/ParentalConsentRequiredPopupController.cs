// ParentalConsentRequiredPopupController
using ClubPenguin;
using ClubPenguin.Analytics;
using ClubPenguin.Mix;
using ClubPenguin.Net;
using ClubPenguin.UI;
using DevonLocalization.Core;
using Disney.Mix.SDK;
using Disney.MobileNetwork;
using Disney.Native;
using UnityEngine;
using UnityEngine.UI;

public class ParentalConsentRequiredPopupController : MonoBehaviour
{
	[Header("Containers")]
	public GameObject NoticeContainer;

	public GameObject ResendContainer;

	public GameObject SentContainer;

	public Text SentText;

	[Header("Buttons")]
	public Button ResendButton;

	public Text ResendButtonText;

	public GameObject ResendButtonPreloader;

	[Header("Parent Email")]
	public InputFieldValidator ParentEmailInputField;

	public Text[] ParentEmailTextObjects;

	private AccountFlowData accountFlowData;

	private SessionManager sessionManager;

	private MixLoginCreateService mixLoginCreateService;

	private void Start()
	{
		Service.Get<ICPSwrveService>().Funnel(Service.Get<MembershipService>().AccountFunnelName, "15", "parental_consent_required");
	}

	private void OnEnable()
	{
		accountFlowData = Service.Get<MembershipService>().GetAccountFlowData();
		if (accountFlowData.FlowType == AccountFlowType.create)
		{
			NoticeContainer.SetActive(value: true);
			ResendContainer.SetActive(value: false);
			SentContainer.SetActive(value: false);
		}
		else
		{
			NoticeContainer.SetActive(value: false);
			ResendContainer.SetActive(value: true);
			ResendButton.interactable = true;
			SentContainer.SetActive(value: false);
		}
		sessionManager = Service.Get<SessionManager>();
		mixLoginCreateService = Service.Get<MixLoginCreateService>();
		Text[] parentEmailTextObjects = ParentEmailTextObjects;
		foreach (Text text in parentEmailTextObjects)
		{
			text.text = sessionManager.LocalUser.RegistrationProfile.ParentEmail;
		}
	}

	private void OnDisable()
	{
		ResendButton.interactable = false;
	}

	public void OnResendButtonClicked()
	{
		ResendButtonText.gameObject.SetActive(value: false);
		ResendButtonPreloader.SetActive(value: true);
		ResendButton.interactable = false;
		if (string.IsNullOrEmpty(ParentEmailInputField.TextInput.text) || ParentEmailInputField.TextInput.text == sessionManager.LocalUser.RegistrationProfile.ParentEmail)
		{
			mixLoginCreateService.OnParentalApprovalEmailSendSuccess += onSendSuccess;
			mixLoginCreateService.ParentalApprovalEmailSend(Service.Get<SessionManager>().LocalUser);
		}
		else
		{
			mixLoginCreateService.OnProfileUpdateSuccess += onParentEmailUpdateSuccess;
			mixLoginCreateService.OnProfileUpdateFailed += onParentEmailUpdateError;
			mixLoginCreateService.UpdateProfile(null, ParentEmailInputField.TextInput.text, null, Service.Get<SessionManager>().LocalUser);
		}
	}

	private void onSendSuccess()
	{
		mixLoginCreateService.OnParentalApprovalEmailSendSuccess -= onSendSuccess;
		MonoSingleton<NativeAccessibilityManager>.Instance.Native.HandleError(SentText.GetInstanceID());
		Service.Get<ICPSwrveService>().Action("parental_consent_required", "resent_email");
		ResendContainer.gameObject.SetActive(value: false);
		ResendButtonText.gameObject.SetActive(value: true);
		ResendButtonPreloader.SetActive(value: false);
		SentContainer.gameObject.SetActive(value: true);
	}

	private void onParentEmailUpdateSuccess()
	{
		mixLoginCreateService.OnProfileUpdateSuccess -= onParentEmailUpdateSuccess;
		mixLoginCreateService.OnProfileUpdateFailed -= onParentEmailUpdateError;
		mixLoginCreateService.OnParentalApprovalEmailSendSuccess += onSendSuccess;
		mixLoginCreateService.ParentalApprovalEmailSend(Service.Get<SessionManager>().LocalUser);
		Text[] parentEmailTextObjects = ParentEmailTextObjects;
		foreach (Text text in parentEmailTextObjects)
		{
			text.text = ParentEmailInputField.TextInput.text;
		}
	}

	public void onParentEmailUpdateError(IUpdateProfileResult result)
	{
		mixLoginCreateService.OnProfileUpdateSuccess -= onParentEmailUpdateSuccess;
		mixLoginCreateService.OnProfileUpdateFailed -= onParentEmailUpdateError;
		ResendContainer.gameObject.SetActive(value: true);
		ResendButtonText.gameObject.SetActive(value: true);
		ResendButtonPreloader.SetActive(value: false);
		ResendButton.interactable = true;
		string text = string.Empty;
		foreach (IInvalidProfileItemError error in result.Errors)
		{
			object obj = text;
			text = obj + "\t[" + error + "]\n";
			if (error is IInvalidParentEmailError)
			{
				ParentEmailInputField.HasError = true;
				string tokenTranslation = Service.Get<Localizer>().GetTokenTranslation("Account.Create.Validation.InvalidEmail");
				ParentEmailInputField.ShowError(tokenTranslation);
			}
			else
			{
				ParentEmailInputField.HasError = true;
				string tokenTranslation = string.Empty;
				tokenTranslation += Service.Get<Localizer>().GetTokenTranslation("Account.Create.Validation.UnknownError");
				ParentEmailInputField.ShowError(tokenTranslation);
			}
		}
	}
}
