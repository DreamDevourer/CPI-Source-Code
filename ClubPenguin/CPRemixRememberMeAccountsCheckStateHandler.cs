// CPRemixRememberMeAccountsCheckStateHandler
using ClubPenguin;
using Disney.Kelowna.Common.SEDFSM;
using Disney.MobileNetwork;

public class CPRemixRememberMeAccountsCheckStateHandler : ActiveStateHandler
{
	public string LoginAccountEvent;

	public string SingleAccountEvent;

	public string MultipleAccountEvent;

	public string SoftLoginEvent;

	public override string HandleStateChange()
	{
		string result = LoginAccountEvent;
		RememberMeService rememberMeService = Service.Get<RememberMeService>();
		int count = rememberMeService.Usernames.Count;
		if (!string.IsNullOrEmpty(rememberMeService.CurrentUsername) && !Service.Get<MembershipService>().LoginViaMembership)
		{
			result = SoftLoginEvent;
		}
		else if (count > 1)
		{
			result = MultipleAccountEvent;
		}
		else if (count == 1)
		{
			result = SingleAccountEvent;
		}
		return result;
	}
}
