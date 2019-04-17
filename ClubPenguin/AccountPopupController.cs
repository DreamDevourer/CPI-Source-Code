// AccountPopupController
using ClubPenguin.UI;
using Disney.MobileNetwork;
using UnityEngine;

public class AccountPopupController : MonoBehaviour
{
	private void Start()
	{
		Service.Get<TrayNotificationManager>().HideNotification();
	}

	private void OnDestroy()
	{
		Service.Get<TrayNotificationManager>().UnhideNotification();
	}

	public void OnClosePopup()
	{
		Object.Destroy(base.gameObject);
	}
}
