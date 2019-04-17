// TubeRaceScoreModifierLayout
using ClubPenguin.PartyGames;
using Disney.Kelowna.Common;
using System.Collections;
using UnityEngine;

public class TubeRaceScoreModifierLayout : MonoBehaviour
{
	public PartyGameDefinition PartyGame;

	public int LayoutId;

	public static readonly PrefabContentKey PositiveIndicatorKey = new PrefabContentKey("Prefabs/TubeRace/PositiveScoreIndicator");

	public static readonly PrefabContentKey NegativeIndicatorKey = new PrefabContentKey("Prefabs/TubeRace/NegativeScoreIndicator");

	private static readonly PrefabContentKey positiveScoreModifierKey = new PrefabContentKey("Prefabs/TubeRace/PositiveScoreModifier");

	private static readonly PrefabContentKey negativeScoreModifierKey = new PrefabContentKey("Prefabs/TubeRace/NegativeScoreModifier");

	public TubeRaceScoreModifier[] getScoreModifiers()
	{
		return GetComponentsInChildren<TubeRaceScoreModifier>(includeInactive: true);
	}

	public void Activate()
	{
		if (!isLayoutActive())
		{
			base.gameObject.SetActive(value: true);
			CoroutineRunner.Start(loadModifierPrefabs(), this, "loadModifierPrefabs");
		}
	}

	public void Deactivate()
	{
		if (isLayoutActive())
		{
			TubeRaceScoreModifier[] scoreModifiers = getScoreModifiers();
			for (int i = 0; i < scoreModifiers.Length; i++)
			{
				scoreModifiers[i].Deactivate();
			}
			base.gameObject.SetActive(value: false);
		}
	}

	private IEnumerator loadModifierPrefabs()
	{
		AssetRequest<GameObject> positiveModifierRequest = Content.LoadAsync(positiveScoreModifierKey);
		yield return positiveModifierRequest;
		AssetRequest<GameObject> negativeModifierRequest = Content.LoadAsync(negativeScoreModifierKey);
		yield return negativeModifierRequest;
		activateModifiers(positiveModifierRequest.Asset, negativeModifierRequest.Asset);
	}

	private void activateModifiers(GameObject positiveModifierPrefab, GameObject negativeModifierPrefab)
	{
		TubeRaceScoreModifier[] scoreModifiers = getScoreModifiers();
		for (int i = 0; i < scoreModifiers.Length; i++)
		{
			scoreModifiers[i].Activate(positiveModifierPrefab, negativeModifierPrefab);
		}
	}

	private bool isLayoutActive()
	{
		return base.gameObject.activeSelf;
	}

	private void OnDestroy()
	{
		CoroutineRunner.StopAllForOwner(this);
	}
}
