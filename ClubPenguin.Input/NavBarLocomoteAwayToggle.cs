// NavBarLocomoteAwayToggle
using ClubPenguin.Input;
using HutongGames.PlayMaker;

[ActionCategory("Input")]
public class NavBarLocomoteAwayToggle : FsmStateAction
{
	public NavBarTitleInputMap InputMap;

	public bool DisableLocomotion;

	public override void OnEnter()
	{
		InputMap.DisableLocomotion = DisableLocomotion;
		Finish();
	}
}
