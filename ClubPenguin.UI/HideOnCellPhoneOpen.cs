// HideOnCellPhoneOpen
using ClubPenguin.CellPhone;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using UnityEngine;

public class HideOnCellPhoneOpen : MonoBehaviour
{
	private void Start()
	{
		Service.Get<EventDispatcher>().AddListener<CellPhoneEvents.CellPhoneOpened>(onCellPhoneOpened);
		Service.Get<EventDispatcher>().AddListener<CellPhoneEvents.CellPhoneClosed>(onCellPhoneClosed);
	}

	private void OnDestroy()
	{
		Service.Get<EventDispatcher>().RemoveListener<CellPhoneEvents.CellPhoneOpened>(onCellPhoneOpened);
		Service.Get<EventDispatcher>().RemoveListener<CellPhoneEvents.CellPhoneClosed>(onCellPhoneClosed);
	}

	private bool onCellPhoneOpened(CellPhoneEvents.CellPhoneOpened evt)
	{
		base.gameObject.SetActive(value: false);
		return false;
	}

	private bool onCellPhoneClosed(CellPhoneEvents.CellPhoneClosed evt)
	{
		base.gameObject.SetActive(value: true);
		return false;
	}
}
