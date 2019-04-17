// UnEquipPropAction
using ClubPenguin;
using ClubPenguin.Locomotion;
using HutongGames.PlayMaker;
using UnityEngine;

[ActionCategory("Quest")]
public class UnEquipPropAction : FsmStateAction
{
	public override void OnEnter()
	{
		GameObject localPlayerGameObject = SceneRefs.ZoneLocalPlayerManager.LocalPlayerGameObject;
		LocomotionUtils.UnEquipProp(localPlayerGameObject);
		Finish();
	}
}
