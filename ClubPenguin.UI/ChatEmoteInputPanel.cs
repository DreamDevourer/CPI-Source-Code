// ChatEmoteInputPanel
using ClubPenguin;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using UnityEngine;

public class ChatEmoteInputPanel : MonoBehaviour
{
	public void OnBackSpaceClicked()
	{
		Service.Get<EventDispatcher>().DispatchEvent(default(ChatEvents.ChatBackSpace));
	}
}
