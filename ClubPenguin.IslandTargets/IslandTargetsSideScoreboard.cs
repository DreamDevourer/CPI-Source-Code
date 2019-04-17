// IslandTargetsSideScoreboard
using ClubPenguin.IslandTargets;
using UnityEngine;

public class IslandTargetsSideScoreboard : MonoBehaviour
{
	public enum SideScoreboardState
	{
		Off,
		ThirtySecsGameStartMark,
		FiveSecsGameStartMark,
		InGame,
		BetweenRounds,
		FinalRound,
		RoundFail,
		WonGame
	}

	public GameObject OffGroup;

	public GameObject InGameGroup;

	public GameObject BetweenRoundsGroup;

	public GameObject FinalRoundGroup;

	public GameObject RoundFailGroup;

	public GameObject WonGameGroup;

	public GameObject ThirtySecsGameStartMarkGroup;

	public GameObject FiveSecsGameStartMarkGroup;

	private Animator animator;

	private string INTRO_ANIM_TRIGGER = "Start";

	private string OUTRO_ANIM_TRIGGER = "End";

	public SideScoreboardState CurrentState
	{
		get;
		private set;
	}

	private void Awake()
	{
		animator = GetComponent<Animator>();
		SetState(SideScoreboardState.Off);
	}

	public void SetState(SideScoreboardState newState)
	{
		switch (newState)
		{
		case SideScoreboardState.Off:
			OffGroup.SetActive(value: true);
			InGameGroup.SetActive(value: false);
			BetweenRoundsGroup.SetActive(value: false);
			FinalRoundGroup.SetActive(value: false);
			RoundFailGroup.SetActive(value: false);
			WonGameGroup.SetActive(value: false);
			ThirtySecsGameStartMarkGroup.SetActive(value: false);
			FiveSecsGameStartMarkGroup.SetActive(value: false);
			if (animator != null && CurrentState != 0)
			{
				animator.SetTrigger(OUTRO_ANIM_TRIGGER);
			}
			break;
		case SideScoreboardState.ThirtySecsGameStartMark:
			OffGroup.SetActive(value: false);
			InGameGroup.SetActive(value: false);
			BetweenRoundsGroup.SetActive(value: false);
			FinalRoundGroup.SetActive(value: false);
			RoundFailGroup.SetActive(value: false);
			WonGameGroup.SetActive(value: false);
			ThirtySecsGameStartMarkGroup.SetActive(value: true);
			FiveSecsGameStartMarkGroup.SetActive(value: false);
			if (animator != null && CurrentState == SideScoreboardState.Off)
			{
				animator.SetTrigger(INTRO_ANIM_TRIGGER);
			}
			break;
		case SideScoreboardState.FiveSecsGameStartMark:
			OffGroup.SetActive(value: false);
			InGameGroup.SetActive(value: false);
			BetweenRoundsGroup.SetActive(value: false);
			FinalRoundGroup.SetActive(value: false);
			RoundFailGroup.SetActive(value: false);
			WonGameGroup.SetActive(value: false);
			ThirtySecsGameStartMarkGroup.SetActive(value: false);
			FiveSecsGameStartMarkGroup.SetActive(value: true);
			if (animator != null && CurrentState == SideScoreboardState.Off)
			{
				animator.SetTrigger(INTRO_ANIM_TRIGGER);
			}
			break;
		case SideScoreboardState.InGame:
			OffGroup.SetActive(value: false);
			InGameGroup.SetActive(value: true);
			BetweenRoundsGroup.SetActive(value: false);
			FinalRoundGroup.SetActive(value: false);
			RoundFailGroup.SetActive(value: false);
			WonGameGroup.SetActive(value: false);
			ThirtySecsGameStartMarkGroup.SetActive(value: false);
			FiveSecsGameStartMarkGroup.SetActive(value: false);
			if (animator != null && CurrentState == SideScoreboardState.Off)
			{
				animator.SetTrigger(INTRO_ANIM_TRIGGER);
			}
			break;
		case SideScoreboardState.BetweenRounds:
			OffGroup.SetActive(value: false);
			InGameGroup.SetActive(value: false);
			BetweenRoundsGroup.SetActive(value: true);
			FinalRoundGroup.SetActive(value: false);
			RoundFailGroup.SetActive(value: false);
			WonGameGroup.SetActive(value: false);
			ThirtySecsGameStartMarkGroup.SetActive(value: false);
			FiveSecsGameStartMarkGroup.SetActive(value: false);
			break;
		case SideScoreboardState.FinalRound:
			OffGroup.SetActive(value: false);
			InGameGroup.SetActive(value: false);
			BetweenRoundsGroup.SetActive(value: false);
			FinalRoundGroup.SetActive(value: true);
			RoundFailGroup.SetActive(value: false);
			WonGameGroup.SetActive(value: false);
			ThirtySecsGameStartMarkGroup.SetActive(value: false);
			FiveSecsGameStartMarkGroup.SetActive(value: false);
			break;
		case SideScoreboardState.RoundFail:
			OffGroup.SetActive(value: false);
			InGameGroup.SetActive(value: false);
			BetweenRoundsGroup.SetActive(value: false);
			FinalRoundGroup.SetActive(value: false);
			RoundFailGroup.SetActive(value: true);
			WonGameGroup.SetActive(value: false);
			ThirtySecsGameStartMarkGroup.SetActive(value: false);
			FiveSecsGameStartMarkGroup.SetActive(value: false);
			break;
		case SideScoreboardState.WonGame:
			OffGroup.SetActive(value: false);
			InGameGroup.SetActive(value: false);
			BetweenRoundsGroup.SetActive(value: false);
			FinalRoundGroup.SetActive(value: false);
			RoundFailGroup.SetActive(value: false);
			WonGameGroup.SetActive(value: true);
			ThirtySecsGameStartMarkGroup.SetActive(value: false);
			FiveSecsGameStartMarkGroup.SetActive(value: false);
			break;
		}
		CurrentState = newState;
	}
}
