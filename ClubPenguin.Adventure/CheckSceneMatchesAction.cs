// CheckSceneMatchesAction
using HutongGames.PlayMaker;
using UnityEngine.SceneManagement;

[ActionCategory("World")]
public class CheckSceneMatchesAction : FsmStateAction
{
	public string SceneName;

	public FsmEvent DoesMatchEvent;

	public FsmEvent DoesNotMatchEvent;

	public override void OnEnter()
	{
		if (SceneManager.GetActiveScene().name == SceneName)
		{
			base.Fsm.Event(DoesMatchEvent);
		}
		else
		{
			base.Fsm.Event(DoesNotMatchEvent);
		}
		Finish();
	}
}
