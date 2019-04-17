// NavBarSecondaryInputHandler
using ClubPenguin.Input;
using Disney.Kelowna.Common.SEDFSM;
using UnityEngine;

public class NavBarSecondaryInputHandler : InputMapHandler<NavBarSecondaryInputMap.Result>
{
	[SerializeField]
	private string target = string.Empty;

	[SerializeField]
	private string targetEvent = string.Empty;

	private new void OnValidate()
	{
	}

	protected override void onHandle(NavBarSecondaryInputMap.Result inputResult)
	{
		if (inputResult.Close.WasJustReleased || inputResult.Locomotion.Direction.sqrMagnitude > 1.401298E-45f)
		{
			StateMachineContext componentInParent = GetComponentInParent<StateMachineContext>();
			componentInParent.SendEvent(new ExternalEvent(target, targetEvent));
		}
	}

	protected override void onReset()
	{
	}
}
