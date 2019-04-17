// CreateFullscreenPopupAction
using ClubPenguin;
using ClubPenguin.Actions;
using Disney.Kelowna.Common;

public class CreateFullscreenPopupAction : Action
{
	public string PopupContentPath;

	protected override void CopyTo(Action _showPopup)
	{
		CreateFullscreenPopupAction createFullscreenPopupAction = _showPopup as CreateFullscreenPopupAction;
		createFullscreenPopupAction.PopupContentPath = PopupContentPath;
		base.CopyTo(_showPopup);
	}

	protected override void Update()
	{
		PrefabContentKey prefabContentKey = new PrefabContentKey(PopupContentPath);
		SceneRefs.FullScreenPopupManager.CreatePopup(prefabContentKey, null);
		Completed();
	}
}
