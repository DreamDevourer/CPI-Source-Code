// SplashScreenEvents
using System.Runtime.InteropServices;

public class SplashScreenEvents
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct SplashScreenOpened
	{
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct SplashScreenClosed
	{
	}
}
