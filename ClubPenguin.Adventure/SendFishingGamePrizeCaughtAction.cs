// SendFishingGamePrizeCaughtAction
using HutongGames.PlayMaker;

[ActionCategory("Deprecated")]
public class SendFishingGamePrizeCaughtAction : FsmStateAction
{
	public override void OnEnter()
	{
		Finish();
	}
}
