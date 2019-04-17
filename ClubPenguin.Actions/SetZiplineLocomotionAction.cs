// SetZiplineLocomotionAction
using ClubPenguin.Actions;
using ClubPenguin.Locomotion;
using Disney.LaunchPadFramework;

public class SetZiplineLocomotionAction : ClubPenguin.Actions.Action
{
	protected override void CopyTo(ClubPenguin.Actions.Action _destAction)
	{
		base.CopyTo(_destAction);
	}

	protected override void Update()
	{
		if (!LocomotionHelper.SetCurrentController<ZiplineController>(GetTarget()))
		{
			Log.LogError(this, "Failed to set the ZiplineController");
		}
		Completed();
	}
}
