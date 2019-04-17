// BaseBackButtonControllerIntegrationTest
using ClubPenguin.UI;
using Disney.Kelowna.Common.Tests;
using Disney.MobileNetwork;
using System.Collections;

public abstract class BaseBackButtonControllerIntegrationTest : BaseIntegrationTest
{
	protected override IEnumerator setup()
	{
		BackButtonController backButtonController = base.gameObject.AddComponent<BackButtonController>();
		Service.Set(backButtonController);
		yield return null;
	}

	protected override IEnumerator runTest()
	{
		yield break;
	}

	protected override void tearDown()
	{
		Service.ResetAll();
	}
}
