// GetMousePosition
using HutongGames.PlayMaker;
using UnityEngine;

[ActionCategory("GUI")]
public class GetMousePosition : FsmStateAction
{
	public FsmVector2 MousePositionVariable;

	public override void OnEnter()
	{
		MousePositionVariable.Value = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		Finish();
	}
}
