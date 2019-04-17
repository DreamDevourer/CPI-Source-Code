// DisableWhenNoGameServer
using ClubPenguin;
using Disney.MobileNetwork;
using UnityEngine;

public class DisableWhenNoGameServer : MonoBehaviour
{
	private void Start()
	{
		if (!IsGameServerAvailable())
		{
			base.gameObject.SetActive(value: false);
		}
	}

	public static bool IsGameServerAvailable()
	{
		GameSettings gameSettings = Service.Get<GameSettings>();
		return !gameSettings.OfflineMode || !string.IsNullOrEmpty(gameSettings.GameServerHost);
	}
}
