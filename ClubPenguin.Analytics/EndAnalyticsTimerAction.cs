// EndAnalyticsTimerAction
using ClubPenguin.Analytics;
using Disney.MobileNetwork;
using HutongGames.PlayMaker;

[ActionCategory("Analytics")]
public class EndAnalyticsTimerAction : FsmStateAction
{
	public FsmString TimerID;

	public override void OnEnter()
	{
		if (!string.IsNullOrEmpty(TimerID.Value))
		{
			Service.Get<ICPSwrveService>().EndTimer(TimerID.Value);
		}
		Finish();
	}
}
