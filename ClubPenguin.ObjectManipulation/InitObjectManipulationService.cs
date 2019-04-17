// InitObjectManipulationService
using ClubPenguin.ObjectManipulation;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using System.Collections;

internal class InitObjectManipulationService : InitActionComponent
{
	public override bool HasSecondPass => false;

	public override bool HasCompletedPass => false;

	public override IEnumerator PerformFirstPass()
	{
		Service.Set(new ObjectManipulationService());
		yield break;
	}
}
