// ChatActiveInputHandler
using ClubPenguin.Input;
using ClubPenguin.UI;
using Disney.Kelowna.Common.SEDFSM;
using UnityEngine;

[RequireComponent(typeof(ChatBarController))]
public class ChatActiveInputHandler : InputMapHandler<ChatActiveInputMap.Result>
{
	[SerializeField]
	private string target = "Root";

	[SerializeField]
	private string targetEvent = "chat_close";

	private ChatBarController chatBarController;

	protected override void Awake()
	{
		chatBarController = GetComponent<ChatBarController>();
		base.Awake();
	}

	protected override void onHandle(ChatActiveInputMap.Result inputResult)
	{
		if (inputResult.Send.WasJustReleased)
		{
			chatBarController.OnSendButtonClicked();
		}
		if (inputResult.Back.WasJustReleased || inputResult.Locomotion.Direction.sqrMagnitude > 1.401298E-45f || (chatBarController.CurrentState == ChatBarState.Instant && inputResult.QuickChat.WasJustReleased) || (chatBarController.CurrentState == ChatBarState.EmoteInstant && inputResult.QuickEmote.WasJustReleased))
		{
			GetComponentInParent<StateMachineContext>().SendEvent(new ExternalEvent(target, targetEvent));
		}
	}

	protected override void onReset()
	{
	}
}
