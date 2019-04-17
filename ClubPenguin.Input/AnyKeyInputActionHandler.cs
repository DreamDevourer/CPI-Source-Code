// AnyKeyInputActionHandler
using ClubPenguin.Input;
using Disney.Kelowna.Common;
using Disney.MobileNetwork;
using System;

public class AnyKeyInputActionHandler : InputMapHandler<AnyKeyInputMap.Result>
{
	public Action OnInputHandled;

	protected override void Awake()
	{
		if (inputMap == null)
		{
			inputMap = Service.Get<InputService>().AnyKeyInputMap;
		}
		base.Awake();
	}

	protected override void onHandle(AnyKeyInputMap.Result inputResult)
	{
		if (inputResult.AnyKey.WasJustReleased)
		{
			OnInputHandled.InvokeSafe();
		}
	}

	protected override void onReset()
	{
	}
}
