// FishingEvents
using ClubPenguin.Adventure;
using ClubPenguin.MiniGames.Fishing;
using System.Runtime.InteropServices;

public static class FishingEvents
{
	public enum FishingState
	{
		Hold,
		Cast
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct UpdateFishingBaitUI
	{
	}

	public struct SetFishingState
	{
		public FishingState State;

		public SetFishingState(FishingState state)
		{
			State = state;
		}
	}

	public struct FishingGameplayStateChanged
	{
		public FishingController.FishingGameplayStates State;

		public FishingGameplayStateChanged(FishingController.FishingGameplayStates state)
		{
			State = state;
		}
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct FishingGameComplete
	{
	}

	public struct SetTimeRemaining
	{
		public int TimeRemaining;

		public SetTimeRemaining(int timeRemaining)
		{
			TimeRemaining = timeRemaining;
		}
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct ActivateBobberButton
	{
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct DeactivateBobberButton
	{
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct PulseBobberButton
	{
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct StopBobberButtonPulse
	{
	}
}
