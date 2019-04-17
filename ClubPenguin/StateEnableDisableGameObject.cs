// StateEnableDisableGameObject
using UnityEngine;

public class StateEnableDisableGameObject : StateMachineBehaviour
{
	public bool EnableOnEnter = false;

	public bool DisableOnExit = false;

	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		if (EnableOnEnter)
		{
			animator.gameObject.SetActive(value: true);
		}
	}

	public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		if (DisableOnExit)
		{
			animator.gameObject.SetActive(value: false);
		}
	}
}
