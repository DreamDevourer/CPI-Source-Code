// PropRevealSpawnedOnRelease
using ClubPenguin.Props;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Prop))]
[RequireComponent(typeof(PropSpawnOnUse))]
public class PropRevealSpawnedOnRelease : MonoBehaviour
{
	private PropSpawnOnUse propSpawnOnUse;

	private Prop prop;

	private void Awake()
	{
		prop = GetComponent<Prop>();
		prop.EActionEventReceived += onActionEventReceived;
		propSpawnOnUse = GetComponent<PropSpawnOnUse>();
	}

	private void onActionEventReceived(string actionEvent)
	{
		if (actionEvent == "release")
		{
			propSpawnOnUse.SpawnedInstance.gameObject.SetActive(value: true);
			propSpawnOnUse.SpawnedInstance.StartExperience();
		}
	}
}
