// SpawnedAction
using ClubPenguin;
using ClubPenguin.Adventure;
using ClubPenguin.Net.Domain;

public class SpawnedAction
{
	public enum SPAWNED_ACTION
	{
		None,
		StartQuest,
		ReplayQuest
	}

	public SPAWNED_ACTION Action = SPAWNED_ACTION.None;

	public Quest Quest;

	public Reward Reward;
}
