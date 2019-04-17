// ConsumableServiceErrors
using System.Runtime.InteropServices;

public static class ConsumableServiceErrors
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct NotEnoughCoins
	{
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct Unknown
	{
	}
}
