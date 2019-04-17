// FlushRecentDecorationsOnDisable
using ClubPenguin.Igloo;
using Disney.MobileNetwork;
using UnityEngine;

public class FlushRecentDecorationsOnDisable : MonoBehaviour
{
	public void OnDisable()
	{
		Service.Get<RecentDecorationsService>()?.FlushPlayerPrefs();
	}
}
