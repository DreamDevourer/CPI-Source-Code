// DanceBattleAnimationCompleteStateBehaviour
using ClubPenguin;
using ClubPenguin.Game.PartyGames;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using UnityEngine;

public class DanceBattleAnimationCompleteStateBehaviour : StateMachineBehaviour
{
	public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		AvatarDataHandle component = animator.GetComponent<AvatarDataHandle>();
		if (component != null && !component.Handle.IsNull)
		{
			Service.Get<EventDispatcher>().DispatchEvent(new DanceBattleEvents.DanceMoveAnimationComplete(component.Handle));
		}
	}
}
