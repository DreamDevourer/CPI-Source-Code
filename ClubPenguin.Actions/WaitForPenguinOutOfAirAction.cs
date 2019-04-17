// WaitForPenguinOutOfAirAction
using ClubPenguin.Actions;
using ClubPenguin.Locomotion;
using UnityEngine;

public class WaitForPenguinOutOfAirAction : Action
{
	private Animator anim;

	protected override void OnEnable()
	{
		anim = GetComponent<Animator>();
		base.OnEnable();
	}

	protected override void Update()
	{
		if (!LocomotionUtils.IsInAir(anim.GetCurrentAnimatorStateInfo(0)))
		{
			Completed();
		}
	}
}
