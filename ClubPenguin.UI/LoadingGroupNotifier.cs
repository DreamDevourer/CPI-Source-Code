// LoadingGroupNotifier
using ClubPenguin.UI;
using UnityEngine;

public class LoadingGroupNotifier : MonoBehaviour
{
	private void Start()
	{
		LoadingGroup componentInParent = GetComponentInParent<LoadingGroup>();
		if (componentInParent != null)
		{
			componentInParent.OnLoadingComplete();
		}
	}
}
