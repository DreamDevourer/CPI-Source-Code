// CrystalPickup
using UnityEngine;

public class CrystalPickup : MonoBehaviour
{
	private void OnTriggerEnter(Collider collider)
	{
		if (!collider.gameObject.CompareTag("Player"))
		{
		}
	}
}
