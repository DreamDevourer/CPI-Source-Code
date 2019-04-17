// ChatActivityServiceEvents
using System.Runtime.InteropServices;

public static class ChatActivityServiceEvents
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct SendChatActivity
	{
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct SendChatActivityCancel
	{
	}
}
