// LoadZoneTest
using ClubPenguin;
using ClubPenguin.Tests;
using Disney.MobileNetwork;
using System.Collections;

public class LoadZoneTest : BaseZoneTranstionTest
{
	protected override IEnumerator setup()
	{
		yield return base.setup();
		eventDispatcher.AddListener<ZoneTransitionEvents.ZoneTransition>(base.onZoneTransition);
	}

	protected override IEnumerator runTest()
	{
		zts.LoadZone(TestZoneDefinition);
		yield return base.runTest();
	}

	protected override void tearDown()
	{
		Service.ResetAll();
	}
}
