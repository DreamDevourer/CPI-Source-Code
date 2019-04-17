// JoystickDisabler
using ClubPenguin.Core;
using ClubPenguin.UI;

public class JoystickDisabler : UIElementDisabler
{
	private VirtualJoystick joystick;

	private void Awake()
	{
		joystick = GetComponentInChildren<VirtualJoystick>();
	}

	public override void DisableElement(bool hide)
	{
		joystick.DisableJoystick();
		changeVisibility(!hide);
		isEnabled = false;
	}

	public override void EnableElement()
	{
		changeVisibility(show: true);
		joystick.EnableJoystick();
		isEnabled = true;
	}
}
