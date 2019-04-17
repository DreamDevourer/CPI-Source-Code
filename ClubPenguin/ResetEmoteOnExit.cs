// ResetEmoteOnExit
using UnityEngine;

public class ResetEmoteOnExit : StateMachineBehaviour
{
	public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		animator.SetInteger("Emote", 0);
	}
}
