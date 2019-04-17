// SetSlideLocomotionAction
using ClubPenguin.Actions;
using ClubPenguin.Locomotion;
using Disney.LaunchPadFramework;

public class SetSlideLocomotionAction : ClubPenguin.Actions.Action
{
	protected override void CopyTo(ClubPenguin.Actions.Action _destAction)
	{
		base.CopyTo(_destAction);
	}

	protected override void Update()
	{
		if (!LocomotionHelper.SetCurrentController<SlideController>(GetTarget()))
		{
			Log.LogError(this, "Failed to set the SlideController");
		}
		Completed();
	}
}
