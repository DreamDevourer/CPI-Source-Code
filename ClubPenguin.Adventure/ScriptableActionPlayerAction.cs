// ScriptableActionPlayerAction
using Disney.Kelowna.Common;
using HutongGames.PlayMaker;
using System.Collections;

[ActionCategory("Automated Testing")]
public class ScriptableActionPlayerAction : FsmStateAction
{
	public ScriptableAction Action;

	public override void OnEnter()
	{
		CoroutineRunner.Start(execute(), this, "ScriptableActionPlayerAction");
	}

	private IEnumerator execute()
	{
		IEnumerator enumerator = Action.Execute(null);
		while (enumerator.MoveNext())
		{
			while (!base.Fsm.Active)
			{
				yield return null;
			}
			yield return enumerator.Current;
		}
		Finish();
	}
}
