// LocomotionControllerSwitch
using ClubPenguin;
using ClubPenguin.Core;
using ClubPenguin.Locomotion;
using System;

public class LocomotionControllerSwitch : Switch
{
	public bool Run;

	public bool Sit;

	public bool Tube;

	public bool Swim;

	public bool Zipline;

	private LocomotionEventBroadcaster locoBroadcaster;

	public override string GetSwitchType()
	{
		throw new NotImplementedException();
	}

	public override object GetSwitchParameters()
	{
		throw new NotImplementedException();
	}

	public void Start()
	{
		locoBroadcaster = ClubPenguin.SceneRefs.ZoneLocalPlayerManager.LocalPlayerGameObject.GetComponent<LocomotionEventBroadcaster>();
		if (locoBroadcaster != null)
		{
			locoBroadcaster.OnControllerChangedEvent += onControllerChanged;
		}
	}

	public void OnDestroy()
	{
		if (locoBroadcaster != null)
		{
			locoBroadcaster.OnControllerChangedEvent -= onControllerChanged;
		}
	}

	private void onControllerChanged(LocomotionController newController)
	{
		if (Run && newController is RunController)
		{
			Change(onoff: true);
		}
		else if (Sit && newController is SitController)
		{
			Change(onoff: true);
		}
		else if (Tube && newController is SlideController)
		{
			Change(onoff: true);
		}
		else if (Swim && newController is SwimController)
		{
			Change(onoff: true);
		}
		else if (Zipline && newController is ZiplineController)
		{
			Change(onoff: true);
		}
		else
		{
			Change(onoff: false);
		}
	}
}
