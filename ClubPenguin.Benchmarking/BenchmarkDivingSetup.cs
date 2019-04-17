// BenchmarkDivingSetup
using ClubPenguin;
using ClubPenguin.Benchmarking;
using ClubPenguin.Collectibles;
using ClubPenguin.Diving;
using ClubPenguin.Locomotion;
using UnityEngine;

public class BenchmarkDivingSetup : BenchmarkTestStage
{
	protected override void setup()
	{
		GameObject localPlayerGameObject = SceneRefs.ZoneLocalPlayerManager.LocalPlayerGameObject;
		localPlayerGameObject.AddComponent(typeof(InvincibleDiver));
		localPlayerGameObject.GetComponent<PenguinInteraction>().enabled = false;
		Chomper[] array = Object.FindObjectsOfType<Chomper>();
		int num = array.Length;
		for (int i = 0; i < num; i++)
		{
			CollectibleOptimizer component = array[i].GetComponent<CollectibleOptimizer>();
			if (component != null)
			{
				component.scriptObjects = new MonoBehaviour[0];
			}
			array[i].enabled = false;
		}
	}

	protected override void performBenchmark()
	{
		onFinish();
	}
}
