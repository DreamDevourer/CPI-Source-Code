// AccountFlowData
using ClubPenguin;
using Disney.Kelowna.Common.DataModel;
using System;
using System.Collections.Generic;

[Serializable]
public class AccountFlowData : ScopedData
{
	public bool LoginViaMembership;

	public bool LoginViaRestore;

	public bool SkipMembership;

	public bool SkipWelcome;

	public List<string> PreValidatedDisplayNames;

	public List<string> PreValidatedUserNames;

	public AccountFlowType FlowType;

	public string Referrer;

	protected override string scopeID => CPDataScopes.Session.ToString();

	protected override Type monoBehaviourType => typeof(AccountFlowDataMonoBehaviour);

	public void Initialize()
	{
		LoginViaMembership = false;
		LoginViaRestore = false;
		SkipMembership = false;
		SkipWelcome = false;
		PreValidatedDisplayNames = new List<string>();
		PreValidatedUserNames = new List<string>();
		FlowType = AccountFlowType.none;
		Referrer = "";
	}

	protected override void notifyWillBeDestroyed()
	{
	}
}
