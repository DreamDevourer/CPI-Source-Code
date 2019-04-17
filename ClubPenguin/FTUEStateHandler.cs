// FTUEStateHandler
using ClubPenguin;
using ClubPenguin.Analytics;
using ClubPenguin.Avatar;
using ClubPenguin.Core;
using Disney.MobileNetwork;

public class FTUEStateHandler : AbstractAccountStateHandler
{
	public void OnStateChanged(string state)
	{
		if (state == HandledState)
		{
			Service.Get<ICPSwrveService>().Funnel(Service.Get<MembershipService>().AccountFunnelName, "01", "ftue_intro");
			CPDataEntityCollection cPDataEntityCollection = Service.Get<CPDataEntityCollection>();
			if (!cPDataEntityCollection.TryGetComponent(cPDataEntityCollection.LocalPlayerHandle, out AvatarDetailsData component))
			{
				component = cPDataEntityCollection.AddComponent<AvatarDetailsData>(cPDataEntityCollection.LocalPlayerHandle);
				component.BodyColor = AvatarService.DefaultBodyColor;
				component.Outfit = new DCustomEquipment[0];
			}
			Service.Get<GameStateController>().StartFTUE();
			AccountPopupController componentInParent = GetComponentInParent<AccountPopupController>();
			componentInParent.OnClosePopup();
		}
	}
}
