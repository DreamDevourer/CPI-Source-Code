// ToggleForMascot
using ClubPenguin.Adventure;
using ClubPenguin.Rewards;
using Disney.MobileNetwork;
using UnityEngine;

public class ToggleForMascot : MonoBehaviour
{
	public MascotDefinitionKey MascotKey;

	private MascotDefinition mascotDefinition;

	private void Start()
	{
		mascotDefinition = Service.Get<MascotService>().GetMascot(MascotKey.Id).Definition;
		DRewardPopup popupData = GetComponentInParent<RewardPopupController>().PopupData;
		if (!string.IsNullOrEmpty(popupData.MascotName) && mascotDefinition != null)
		{
			toggleForMascot(popupData.MascotName);
		}
	}

	private void toggleForMascot(string mascotName)
	{
		Mascot mascot = Service.Get<MascotService>().GetMascot(mascotName);
		if (mascot != null)
		{
			if (mascotDefinition.name == mascot.Definition.name)
			{
				base.gameObject.SetActive(value: true);
			}
			else
			{
				base.gameObject.SetActive(value: false);
			}
		}
	}
}
