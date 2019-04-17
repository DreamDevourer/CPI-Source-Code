// IglooCreateButton
using ClubPenguin;
using UnityEngine;
using UnityEngine.UI;

internal class IglooCreateButton : MonoBehaviour
{
	public GameObject LockedOverlay;

	public GameObject MemberLockedOverlay;

	public GameObject ProgressionLockedOverlay;

	public Transform GetSlotContainer => base.transform.parent;

	public void SetState(IglooPropertiesCard.IglooCardState state)
	{
		switch (state)
		{
		case IglooPropertiesCard.IglooCardState.MemberLocked:
			LockedOverlay.SetActive(value: true);
			MemberLockedOverlay.SetActive(value: true);
			break;
		case IglooPropertiesCard.IglooCardState.ProgressionLocked:
			LockedOverlay.SetActive(value: true);
			ProgressionLockedOverlay.SetActive(value: true);
			break;
		default:
			LockedOverlay.SetActive(value: false);
			MemberLockedOverlay.SetActive(value: false);
			ProgressionLockedOverlay.SetActive(value: false);
			break;
		}
	}

	public void SetLockedLevel(int level)
	{
		Text componentInChildren = ProgressionLockedOverlay.GetComponentInChildren<Text>();
		if (componentInChildren != null)
		{
			componentInChildren.text = level.ToString();
		}
	}
}
