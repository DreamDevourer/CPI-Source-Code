// ChangeCameraTargetActionSettings
using ClubPenguin.Core;
using HutongGames.PlayMaker;
using System;

[Serializable]
public class ChangeCameraTargetActionSettings : AbstractAspectRatioSpecificSettings
{
	public string TargetName;

	public FsmOwnerDefault TargetGameObject;
}
