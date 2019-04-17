// DanceBattleAnimationEventHandler
using System;
using UnityEngine;

public class DanceBattleAnimationEventHandler : MonoBehaviour
{
	public Action OnStartTurnSequence;

	public void StartTurnSequence()
	{
		if (OnStartTurnSequence != null)
		{
			OnStartTurnSequence();
		}
	}
}
