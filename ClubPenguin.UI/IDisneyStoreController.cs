// IDisneyStoreController
using ClubPenguin.UI;
using UnityEngine;

public interface IDisneyStoreController
{
	DisneyStoreTrayAnimator GetTrayAnimator();

	void OnCloseClicked();

	void ShowLoadingModal();

	void HideLoadingModal();

	void onLoadingModalLoadComplete(string Path, GameObject loadingModalPrefab);
}
