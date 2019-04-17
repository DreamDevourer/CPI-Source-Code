// FindFourHud
using ClubPenguin.Core;
using ClubPenguin.Game.PartyGames;
using Disney.Kelowna.Common;
using Disney.MobileNetwork;
using Fabric;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindFourHud : MonoBehaviour
{
	public enum FindFourHudState
	{
		Instructions,
		PickingTurn,
		InGame,
		YourTurnText
	}

	public GameObject InstructionText;

	public GameObject PickingTurnTextPanel;

	public GameObject GamePanel;

	public GameObject PlayerUIPanel;

	public GameObject YourTurnText;

	public float InstructionTime = 2.5f;

	public float YourTurnTextTime = 2f;

	[Space(10f)]
	public string GameInstructionSFXTrigger;

	public string YourTurnSFXTrigger;

	public string OpponentTurnSFXTrigger;

	private Dictionary<long, FindFourPlayerHud> playerHuds;

	private FindFourPlayerHud currentPlayerHud;

	private float turnTime;

	private PrefabContentKey PLAYER_HUD_KEY = new PrefabContentKey("Prefabs/FindFour/PlayerTokenItem");

	public FindFourHudState HudState
	{
		get;
		private set;
	}

	private void Start()
	{
	}

	public void Init(long[] playerIds, FindFourDefinition definition)
	{
		turnTime = (float)definition.TurnTimeInSeconds + -1f;
		CoroutineRunner.Start(loadPlayerHuds(playerIds), this, "loadPlayerHuds");
	}

	private IEnumerator loadPlayerHuds(long[] playerIds)
	{
		AssetRequest<GameObject> request = Content.LoadAsync(PLAYER_HUD_KEY);
		yield return request;
		playerHuds = new Dictionary<long, FindFourPlayerHud>();
		for (int i = 0; i < playerIds.Length; i++)
		{
			FindFourPlayerHud component = Object.Instantiate(request.Asset, PlayerUIPanel.transform, worldPositionStays: false).GetComponent<FindFourPlayerHud>();
			component.Init(playerIds[i], i);
			playerHuds[playerIds[i]] = component;
		}
	}

	public void SetState(FindFourHudState newState)
	{
		switch (newState)
		{
		case FindFourHudState.Instructions:
			InstructionText.SetActive(value: true);
			PickingTurnTextPanel.SetActive(value: false);
			GamePanel.SetActive(value: false);
			EventManager.Instance.PostEvent(GameInstructionSFXTrigger, EventAction.PlaySound);
			CoroutineRunner.Start(switchToPickingTurn(), this, "");
			break;
		case FindFourHudState.PickingTurn:
			InstructionText.SetActive(value: false);
			PickingTurnTextPanel.SetActive(value: true);
			GamePanel.SetActive(value: false);
			break;
		case FindFourHudState.InGame:
			InstructionText.SetActive(value: false);
			PickingTurnTextPanel.SetActive(value: false);
			GamePanel.SetActive(value: true);
			PlayerUIPanel.SetActive(value: true);
			YourTurnText.SetActive(value: false);
			break;
		case FindFourHudState.YourTurnText:
			InstructionText.SetActive(value: false);
			PickingTurnTextPanel.SetActive(value: false);
			GamePanel.SetActive(value: true);
			PlayerUIPanel.SetActive(value: false);
			YourTurnText.SetActive(value: true);
			CoroutineRunner.Start(hideYourTurnText(), this, "");
			break;
		}
		HudState = newState;
	}

	private IEnumerator switchToPickingTurn()
	{
		yield return new WaitForSeconds(InstructionTime);
		SetState(FindFourHudState.PickingTurn);
	}

	private IEnumerator hideYourTurnText()
	{
		yield return new WaitForSeconds(YourTurnTextTime);
		SetState(FindFourHudState.InGame);
	}

	public void SetCurrentPlayersTurn(long playerId)
	{
		if (currentPlayerHud != null)
		{
			currentPlayerHud.SetHighlighted(highlighted: false);
		}
		currentPlayerHud = playerHuds[playerId];
		currentPlayerHud.SetHighlighted(highlighted: true);
		if (playerId == Service.Get<CPDataEntityCollection>().LocalPlayerSessionId)
		{
			currentPlayerHud.StartTimer(turnTime - YourTurnTextTime);
			SetState(FindFourHudState.YourTurnText);
			EventManager.Instance.PostEvent(YourTurnSFXTrigger, EventAction.PlaySound);
		}
		else
		{
			currentPlayerHud.StartTimer(turnTime);
			EventManager.Instance.PostEvent(OpponentTurnSFXTrigger, EventAction.PlaySound);
		}
	}

	public void EndTurn()
	{
		currentPlayerHud.StopTimer();
	}
}
