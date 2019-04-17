// StartDanceBattleQuestGameAction
using ClubPenguin.Adventure;
using HutongGames.PlayMaker;
using UnityEngine;

public class StartDanceBattleQuestGameAction : FsmStateAction
{
	public override void OnEnter()
	{
		DanceBattleQuestGameController danceBattleQuestGameController = Object.FindObjectOfType<DanceBattleQuestGameController>();
		if (danceBattleQuestGameController != null)
		{
			danceBattleQuestGameController.StartGame();
		}
		Finish();
	}
}
