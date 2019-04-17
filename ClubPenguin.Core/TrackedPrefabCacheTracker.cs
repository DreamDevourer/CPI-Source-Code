// TrackedPrefabCacheTracker
using ClubPenguin.Core;
using Disney.Kelowna.Common;
using UnityEngine;

public class TrackedPrefabCacheTracker : MonoBehaviour
{
	private PrefabCacheTracker prefabCacheTracker;

	private void Awake()
	{
		prefabCacheTracker = base.gameObject.AddComponent<PrefabCacheTracker>();
		SceneRefs.Set(prefabCacheTracker);
	}

	private void OnDestroy()
	{
		SceneRefs.Remove(prefabCacheTracker);
	}
}
