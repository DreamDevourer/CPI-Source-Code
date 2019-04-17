// FindUserItem
using ClubPenguin;
using ClubPenguin.Core;
using ClubPenguin.Net;
using ClubPenguin.UI;
using Disney.Kelowna.Common.DataModel;
using Disney.MobileNetwork;
using UnityEngine;
using UnityEngine.UI;

public class FindUserItem : MonoBehaviour
{
	public Text NameText;

	public GameObject FriendRequestPendingContainer;

	public GameObject AlreadyFriendsContainer;

	public GameObject SendFriendRequestContainer;

	public GameObject IncomingRequestContainer;

	public GameObject FriendAvatarIconContainer;

	public GameObject PreloadPanel;

	public RawImage FriendAvatarIcon;

	private DataEntityHandle handle;

	public void OnEnable()
	{
		deactivateAllElements();
		NameText.text = "";
	}

	public void SetPlayer(DataEntityHandle handle)
	{
		this.handle = handle;
	}

	public void SetName(string displayName)
	{
		NameText.text = displayName;
	}

	public void SetFriendStatus(FriendStatus friendStatus)
	{
		deactivateAllElements();
		switch (friendStatus)
		{
		case FriendStatus.Self:
			break;
		case FriendStatus.None:
			goToNoneState();
			break;
		case FriendStatus.OutgoingInvite:
			goToPendingState();
			break;
		case FriendStatus.IncomingInvite:
			IncomingRequestContainer.SetActive(value: true);
			break;
		case FriendStatus.Friend:
			goToFriendsState();
			break;
		}
	}

	public void SetAvatarIcon(Texture2D icon)
	{
		FriendAvatarIcon.texture = icon;
	}

	public void SetAvatarIconActive(bool isActive)
	{
		FriendAvatarIconContainer.SetActive(isActive);
	}

	public void SetPreloaderActive(bool isActive)
	{
		PreloadPanel.SetActive(isActive);
	}

	private void deactivateAllElements()
	{
		AlreadyFriendsContainer.SetActive(value: false);
		FriendRequestPendingContainer.SetActive(value: false);
		SendFriendRequestContainer.SetActive(value: false);
		IncomingRequestContainer.SetActive(value: false);
	}

	public void SendFriendInvitationButtonClicked()
	{
		SearchedUserData component = Service.Get<CPDataEntityCollection>().GetComponent<SearchedUserData>(handle);
		Service.Get<INetworkServicesManager>().FriendsService.SendFriendInvitation(component.SearchedUser, Service.Get<SessionManager>().LocalUser);
		deactivateAllElements();
		goToPendingState();
	}

	private void goToPendingState()
	{
		FriendRequestPendingContainer.SetActive(value: true);
	}

	private void goToFriendsState()
	{
		AlreadyFriendsContainer.SetActive(value: true);
	}

	private void goToNoneState()
	{
		SendFriendRequestContainer.SetActive(value: true);
	}

	public void AcceptFriendInvitationButtonClicked()
	{
		IncomingFriendInvitationData component = Service.Get<CPDataEntityCollection>().GetComponent<IncomingFriendInvitationData>(handle);
		Service.Get<INetworkServicesManager>().FriendsService.AcceptFriendInvitation(component.Invitation, Service.Get<SessionManager>().LocalUser);
		deactivateAllElements();
		goToFriendsState();
	}

	public void DeclineFriendInvitationButtonClicked()
	{
		IncomingFriendInvitationData component = Service.Get<CPDataEntityCollection>().GetComponent<IncomingFriendInvitationData>(handle);
		Service.Get<INetworkServicesManager>().FriendsService.RejectFriendInvitation(component.Invitation, Service.Get<SessionManager>().LocalUser);
		deactivateAllElements();
		goToNoneState();
	}

	public void PlayerCardButtonClicked()
	{
		OpenPlayerCardCommand openPlayerCardCommand = new OpenPlayerCardCommand(handle);
		openPlayerCardCommand.Execute();
	}
}
