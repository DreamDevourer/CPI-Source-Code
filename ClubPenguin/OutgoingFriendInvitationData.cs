// OutgoingFriendInvitationData
using ClubPenguin;
using Disney.Kelowna.Common.DataModel;
using Disney.Mix.SDK;
using System;

[Serializable]
public class OutgoingFriendInvitationData : ScopedData
{
	private IOutgoingFriendInvitation invitation;

	public IOutgoingFriendInvitation Invitation => invitation;

	protected override string scopeID => CPDataScopes.Session.ToString();

	protected override Type monoBehaviourType => typeof(OutgoingFriendInvitationDataMonoBehaviour);

	public event Action<string, IFriend> OnAccepted;

	public event Action<string> OnRejected;

	public void Init(IOutgoingFriendInvitation invitation)
	{
		this.invitation = invitation;
		invitation.OnAccepted += onFriendAccepted;
		invitation.OnRejected += onFriendRejected;
	}

	private void removeListeners()
	{
		invitation.OnAccepted -= onFriendAccepted;
		invitation.OnRejected -= onFriendRejected;
		this.OnAccepted = null;
		this.OnRejected = null;
	}

	private void onFriendAccepted(object sender, AbstractFriendInvitationAcceptedEventArgs eventArgs)
	{
		if (this.OnAccepted != null)
		{
			this.OnAccepted(invitation.Invitee.DisplayName.Text, eventArgs.Friend);
		}
	}

	private void onFriendRejected(object sender, AbstractFriendInvitationRejectedEventArgs eventArgs)
	{
		if (this.OnRejected != null)
		{
			this.OnRejected(((IOutgoingFriendInvitation)sender).Invitee.DisplayName.Text);
		}
	}

	protected override void notifyWillBeDestroyed()
	{
		removeListeners();
	}
}
