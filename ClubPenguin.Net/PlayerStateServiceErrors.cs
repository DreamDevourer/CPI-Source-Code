// PlayerStateServiceErrors
using System.Runtime.InteropServices;

public static class PlayerStateServiceErrors
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct PlayerOutfitChangeError
	{
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct PlayerProfileChangeError
	{
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct LegacyAccountMigrationError
	{
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct PlayerProfileError
	{
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct PlayerReferralError
	{
	}
}
