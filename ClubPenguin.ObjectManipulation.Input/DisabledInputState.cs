// DisabledInputState
using ClubPenguin.ObjectManipulation.Input;
using Disney.Kelowna.Common;

public class DisabledInputState : AbstractInputInteractionState
{
	public DisabledInputState()
	{
		state = InteractionState.DisabledInput;
	}

	protected override void processOneTouch(TouchEquivalent touch)
	{
	}
}
