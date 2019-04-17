// QuestHudHiddenStateMachineBehaviour
using ClubPenguin.UI;
using UnityEngine;

public class QuestHudHiddenStateMachineBehaviour : StateMachineBehaviour
{
	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		animator.gameObject.GetComponent<QuestHud>().OnHiddenStateMachineBehaviourEnter();
	}

	public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		animator.gameObject.GetComponent<QuestHud>().OnHiddenStateMachineBehaviourExit();
	}
}
