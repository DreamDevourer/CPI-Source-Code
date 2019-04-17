// AnniversaryCutsceneController
using ClubPenguin.SpecialEvents;

public class AnniversaryCutsceneController : AbstractEventCutsceneController
{
	public override void Awake()
	{
		base.Awake();
		eventChannel.AddListener<WorldEventEvents.CutsceneComplete>(onCutsceneComplete);
	}

	protected override void handleNoSubEvent()
	{
	}

	protected override void handleDecorationsLoaded(EventCutsceneEvent cutsceneEvent)
	{
	}

	protected override void handleCutsceneLoaded(EventCutsceneEvent cutsceneEvent)
	{
	}

	private bool onCutsceneComplete(WorldEventEvents.CutsceneComplete evt)
	{
		removeLoadedScenes();
		return false;
	}
}
