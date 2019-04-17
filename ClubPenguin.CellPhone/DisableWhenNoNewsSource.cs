// DisableWhenNoNewsSource
using ClubPenguin;
using Disney.MobileNetwork;
using UnityEngine;

public class DisableWhenNoNewsSource : MonoBehaviour
{
	private void Start()
	{
		GameSettings gameSettings = Service.Get<GameSettings>();
		if (gameSettings.OfflineMode && string.IsNullOrEmpty(gameSettings.CPWebsiteAPIServicehost))
		{
			base.gameObject.SetActive(value: false);
		}
	}
}
