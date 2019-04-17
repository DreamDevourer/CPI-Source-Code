// PenguinControlsChatInputHandler
using ClubPenguin.Core;
using ClubPenguin.Input;
using UnityEngine;

public class PenguinControlsChatInputHandler : PenguinControlsInputHandlerLib<PenguinControlsChatInputMap.Result>
{
	protected override void onHandle(PenguinControlsChatInputMap.Result inputResult)
	{
		handleLocomotionInput(inputResult.Locomotion);
	}

	protected override void onReset()
	{
		eventDispatcher.DispatchEvent(new InputEvents.MoveEvent(Vector2.zero));
	}
}
