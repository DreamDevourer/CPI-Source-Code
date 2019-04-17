// IncrementDailyPlayCountLocallyAction
using HutongGames.PlayMaker;

public class IncrementDailyPlayCountLocallyAction : FsmStateAction
{
	public FsmString GameId = "fishing";

	public override void OnEnter()
	{
		Finish();
	}
}
