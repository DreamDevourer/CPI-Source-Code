// HideRemotePlayersAction
using ClubPenguin;
using HutongGames.PlayMaker;

[ActionCategory("Quest")]
public class HideRemotePlayersAction : FsmStateAction
{
	public override void OnEnter()
	{
		RemotePlayerVisibilityState.HideRemotePlayers();
		Finish();
	}
}
