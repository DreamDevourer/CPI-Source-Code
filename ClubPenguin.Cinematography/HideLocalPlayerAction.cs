// HideLocalPlayerAction
using HutongGames.PlayMaker;
using UnityEngine;

[ActionCategory("Cinematography")]
public class HideLocalPlayerAction : FsmStateAction
{
	public override void OnEnter()
	{
		Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("LocalPlayer"));
		Finish();
	}
}
