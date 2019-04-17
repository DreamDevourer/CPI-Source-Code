// GetCurrentQuestPathNodeAction
using ClubPenguin.Adventure;
using HutongGames.PlayMaker;

[ActionCategory("Quest")]
public class GetCurrentQuestPathNodeAction : FsmStateAction
{
	public FsmGameObject QuestPathObject;

	public FsmGameObject OUT_NodeObject;

	public override void OnEnter()
	{
		QuestPath component = QuestPathObject.Value.GetComponent<QuestPath>();
		if (component != null)
		{
			OUT_NodeObject.Value = component.GetCurrentNode();
		}
		Finish();
	}
}
