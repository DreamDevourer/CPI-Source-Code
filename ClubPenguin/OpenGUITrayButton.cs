// OpenGUITrayButton
using ClubPenguin.UI;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using UnityEngine;
using UnityEngine.UI;

public class OpenGUITrayButton : MonoBehaviour
{
	private const bool IS_PERSISTENT = true;

	public Image MainNavButtonIcon;

	private void Start()
	{
		Service.Get<EventDispatcher>().AddListener<TrayEvents.TrayOpened>(onTrayOpened);
		Service.Get<EventDispatcher>().AddListener<TrayEvents.TrayClosed>(onTrayClosed);
		base.gameObject.SetActive(value: false);
	}

	public void OnClick()
	{
		base.gameObject.SetActive(value: false);
		Service.Get<EventDispatcher>().DispatchEvent(new TrayEvents.OpenTray(isPersistent: true));
	}

	private bool onTrayOpened(TrayEvents.TrayOpened evt)
	{
		base.gameObject.SetActive(value: false);
		MainNavButtonIcon.enabled = true;
		base.transform.GetComponent<Button>().interactable = base.transform.parent.GetComponent<Button>().interactable;
		return false;
	}

	private bool onTrayClosed(TrayEvents.TrayClosed evt)
	{
		base.gameObject.SetActive(value: true);
		MainNavButtonIcon.enabled = false;
		base.transform.GetComponent<Button>().interactable = base.transform.parent.GetComponent<Button>().interactable;
		return false;
	}

	private void OnDestroy()
	{
		Service.Get<EventDispatcher>().RemoveListener<TrayEvents.TrayOpened>(onTrayOpened);
		Service.Get<EventDispatcher>().RemoveListener<TrayEvents.TrayClosed>(onTrayClosed);
	}
}
