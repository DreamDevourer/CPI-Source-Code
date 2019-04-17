// ShowRemotePlayersAction
using ClubPenguin;
using HutongGames.PlayMaker;

[ActionCategory("Quest")]
public class ShowRemotePlayersAction : FsmStateAction
{
	public override void OnEnter()
	{
		RemotePlayerVisibilityState.ShowRemotePlayers();
		Finish();
	}
}
