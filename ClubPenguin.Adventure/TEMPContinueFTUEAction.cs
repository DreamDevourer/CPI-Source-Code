// TEMPContinueFTUEAction
using ClubPenguin;
using Disney.MobileNetwork;
using HutongGames.PlayMaker;

[ActionCategory("Quest")]
public class TEMPContinueFTUEAction : FsmStateAction
{
	public override void OnEnter()
	{
		Service.Get<GameStateController>().ContinueFTUE();
		Finish();
	}
}
