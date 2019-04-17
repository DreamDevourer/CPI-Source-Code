// SearchedUserData
using ClubPenguin;
using Disney.Kelowna.Common.DataModel;
using Disney.Mix.SDK;
using System;

[Serializable]
public class SearchedUserData : ScopedData
{
	public IUnidentifiedUser SearchedUser
	{
		get;
		set;
	}

	protected override Type monoBehaviourType => typeof(SearchedUserDataMonoBehaviour);

	protected override string scopeID => CPDataScopes.Zone.ToString();

	protected override void notifyWillBeDestroyed()
	{
	}
}
