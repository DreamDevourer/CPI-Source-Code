// LoginOrCreateContentController
using ClubPenguin;
using ClubPenguin.Analytics;
using Disney.MobileNetwork;
using UnityEngine;

public class LoginOrCreateContentController : MonoBehaviour
{
	private void Start()
	{
		Service.Get<ICPSwrveService>().Funnel(Service.Get<MembershipService>().AccountFunnelName, "02", "login_create_prompt");
	}
}
