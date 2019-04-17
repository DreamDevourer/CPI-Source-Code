// SpawnOnDestroy
using UnityEngine;

public class SpawnOnDestroy : MonoBehaviour
{
	public GameObject PrefabToCreate = null;

	private void OnDestroy()
	{
		if (PrefabToCreate != null)
		{
			GameObject gameObject = Object.Instantiate(PrefabToCreate);
			gameObject.transform.SetParent(null);
		}
	}
}
