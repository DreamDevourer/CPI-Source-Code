// ScriptableActionStringInjectionAction
using ClubPenguin.Adventure;
using HutongGames.PlayMaker;

public class ScriptableActionStringInjectionAction : ScriptableActionInjectionAction<FsmString>
{
	protected override object getDataObject()
	{
		return DataObject.Value;
	}
}
