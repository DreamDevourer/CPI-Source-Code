// VirtualJoystickEvents
using ClubPenguin.Core;
using System.Runtime.InteropServices;

public class VirtualJoystickEvents
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct JoystickActivated
	{
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct JoystickDeactivated
	{
	}

	public struct JoystickAdded
	{
		public VirtualJoystick Joystick;

		public JoystickAdded(VirtualJoystick joystick)
		{
			Joystick = joystick;
		}
	}
}
