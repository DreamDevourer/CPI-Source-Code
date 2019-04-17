// GetLocalPlayerNameAction
using ClubPenguin;
using ClubPenguin.Core;
using Disney.MobileNetwork;
using HutongGames.PlayMaker;

[ActionCategory("Misc")]
public class GetLocalPlayerNameAction : FsmStateAction
{
	[RequiredField]
	public FsmString storeValue;

	public override void Reset()
	{
		storeValue = "";
	}

	public override void OnEnter()
	{
		CPDataEntityCollection cPDataEntityCollection = Service.Get<CPDataEntityCollection>();
		string displayName = cPDataEntityCollection.GetComponent<DisplayNameData>(cPDataEntityCollection.LocalPlayerHandle).DisplayName;
		storeValue.Value = displayName;
		Finish();
	}
}
