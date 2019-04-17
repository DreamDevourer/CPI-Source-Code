// AnimationLogger
using ClubPenguin;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationLogger : MonoBehaviour
{
	private Animator anim;

	private bool prevIsInTransition;

	private int prevState;

	public void Awake()
	{
		anim = GetComponent<Animator>();
		prevState = anim.GetCurrentAnimatorStateInfo(0).fullPathHash;
	}

	private string TransitionToString(AnimatorTransitionInfo info)
	{
		return $"Transition: {AnimationHashes.ToString(info.fullPathHash)}\nAny State: {info.anyState}\nNormalized Time: {info.normalizedTime}";
	}

	private string StateToString(AnimatorStateInfo info)
	{
		return $"State: {AnimationHashes.ToString(info.fullPathHash)}\nLength: {info.length}\nLoop: {info.loop}\nNormalized Time: {info.normalizedTime}";
	}

	private void LogMsg(string label, string str)
	{
	}

	private void LogMsg(string str)
	{
	}

	public void Update()
	{
		bool flag = anim.IsInTransition(0);
		if (prevIsInTransition != flag)
		{
			if (flag)
			{
				LogMsg("Start Transition", TransitionToString(anim.GetAnimatorTransitionInfo(0)));
			}
			else
			{
				LogMsg("End transition");
			}
			prevIsInTransition = flag;
		}
		AnimatorStateInfo currentAnimatorStateInfo = anim.GetCurrentAnimatorStateInfo(0);
		int fullPathHash = currentAnimatorStateInfo.fullPathHash;
		if (fullPathHash != prevState)
		{
			LogMsg("New state", StateToString(currentAnimatorStateInfo));
			prevState = fullPathHash;
		}
	}
}
