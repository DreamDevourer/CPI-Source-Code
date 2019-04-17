// BlockAndLockRestartButton
using ClubPenguin.MiniGames.BlockAndLock;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class BlockAndLockRestartButton : MonoBehaviour
{
	private Button button;

	private EventDispatcher dispatcher;

	private void Awake()
	{
		dispatcher = Service.Get<EventDispatcher>();
	}

	private void Start()
	{
		button = GetComponent<Button>();
		button.onClick.AddListener(onButton);
	}

	private void onButton()
	{
		dispatcher.DispatchEvent(default(BlockAndLockEvents.RestartButton));
	}

	private void OnDestroy()
	{
		button.onClick.RemoveListener(onButton);
	}
}
