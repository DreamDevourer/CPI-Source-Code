// EquipItemAction
using ClubPenguin.Props;
using Disney.MobileNetwork;
using HutongGames.PlayMaker;

[ActionCategory("Props")]
public class EquipItemAction : FsmStateAction
{
	[RequiredField]
	public PropDefinition propDefinition;

	public override void OnEnter()
	{
		if (!string.IsNullOrEmpty(propDefinition.GetNameOnServer()))
		{
			Service.Get<PropService>().LocalPlayerRetrieveProp(propDefinition.GetNameOnServer());
		}
		Finish();
	}
}
