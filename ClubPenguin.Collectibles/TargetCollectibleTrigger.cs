// TargetCollectibleTrigger
using ClubPenguin.Collectibles;
using UnityEngine;

public class TargetCollectibleTrigger : MonoBehaviour
{
	private bool isPickupable = false;

	private SceneryCollectible colliderScript;

	private Collider triggerColl;

	public void Init()
	{
		triggerColl = GetComponent<Collider>();
	}

	private void OnTriggerStay(Collider collider)
	{
		if (isPickupable && collider.gameObject.CompareTag("Player"))
		{
			base.gameObject.SendMessageUpwards("OnPickedUp", SendMessageOptions.RequireReceiver);
			triggerColl.enabled = false;
		}
	}

	public void IsCollectible(bool value)
	{
		isPickupable = value;
		triggerColl.enabled = value;
	}
}
