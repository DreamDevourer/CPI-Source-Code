// NotificationContainer
using ClubPenguin.UI;
using Disney.MobileNetwork;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class NotificationContainer : MonoBehaviour
{
	private void Start()
	{
		Service.Get<TrayNotificationManager>().SetParentRectTransform((RectTransform)base.transform);
	}
}
