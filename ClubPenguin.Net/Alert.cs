// Alert
using ClubPenguin.Net;
using DevonLocalization.Core;
using Disney.Mix.SDK;
using Disney.MobileNetwork;

public class Alert : IModerationAlert
{
	private IAlert mixAlert;

	private bool isCritical;

	public bool IsCritical => isCritical;

	public string Text => Service.Get<Localizer>().GetTokenTranslation("Account.WarningText." + MixAlert.Type + mixAlert.Level);

	public IAlert MixAlert => mixAlert;

	public Alert(IAlert mixAlert, bool isCritical)
	{
		this.mixAlert = mixAlert;
		this.isCritical = isCritical;
	}
}
