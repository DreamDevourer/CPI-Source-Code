// InputMediator
using ClubPenguin.Input;
using ClubPenguin.UI;
using Disney.LaunchPadFramework;

public class InputMediator
{
	public InputMediator(EventDispatcher eventDispatcher)
	{
		eventDispatcher.AddListener<UIEvents.ModalBackgroundShown>(onModalBackgroundShown);
	}

	private bool onModalBackgroundShown(UIEvents.ModalBackgroundShown evt)
	{
		evt.ModalBackground.AddComponent<ModalInputHandler>();
		return false;
	}
}
