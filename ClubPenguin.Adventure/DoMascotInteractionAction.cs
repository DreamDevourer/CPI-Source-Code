// DoMascotInteractionAction
using ClubPenguin;
using ClubPenguin.Actions;
using ClubPenguin.Adventure;

public class DoMascotInteractionAction : Action
{
	private MascotController mascotController;

	protected override void OnEnable()
	{
		if (Owner.CompareTag("Player"))
		{
			mascotController = SceneRefs.ActionSequencer.GetTrigger(Owner).GetComponentInParent<MascotController>();
			mascotController.StartInteraction();
		}
	}

	protected override void Update()
	{
		if (Owner.CompareTag("Player"))
		{
			if (mascotController.IsInteractionDone())
			{
				Completed();
			}
		}
		else
		{
			Completed();
		}
	}
}
