// CameraSnapAction
using ClubPenguin.Cinematography;
using ClubPenguin.Core;
using HutongGames.PlayMaker;

[ActionCategory("Quest")]
public class CameraSnapAction : FsmStateAction
{
	public override void OnEnter()
	{
		SceneRefs.Get<BaseCamera>().Snap();
		Finish();
	}
}
