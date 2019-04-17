// IslandTargetsPlayground
using ClubPenguin.ScheduledWorldObjects;
using UnityEngine;

public class IslandTargetsPlayground : MonoBehaviour
{
	[Range(1f, 59f)]
	[Tooltip("Every x minutes after the hour")]
	public int EveryXMinutesAfterTheHour = 2;

	[Tooltip("Selection behaviour for how the server determines which group of targets is shown next")]
	public SelectionBehaviour Behaviour = SelectionBehaviour.NonRepeatingRandom;
}
