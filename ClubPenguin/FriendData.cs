// FriendData
using ClubPenguin;
using Disney.Kelowna.Common.DataModel;
using Disney.Mix.SDK;
using System;

[Serializable]
public class FriendData : ScopedData
{
	public IFriend Friend
	{
		get;
		set;
	}

	protected override Type monoBehaviourType => typeof(FriendDataMonoBehaviour);

	protected override string scopeID => CPDataScopes.Session.ToString();

	protected override void notifyWillBeDestroyed()
	{
	}
}
