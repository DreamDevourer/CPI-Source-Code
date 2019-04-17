// Alert
using Disney.Mix.SDK;
using Disney.Mix.SDK.Internal;
using Disney.Mix.SDK.Internal.MixDomain;

public class Alert : IInternalAlert, IAlert
{
	private readonly int level;

	public int Level => level;

	public AlertType Type
	{
		get;
		private set;
	}

	public long AlertId
	{
		get;
		private set;
	}

	public Alert(int level, AlertType type, long alertId)
	{
		this.level = level;
		Type = type;
		AlertId = alertId;
	}

	public Alert(string level, string type, long alertId)
	{
		int.TryParse(level, out this.level);
		Type = AlertTypeUtils.FromString(type);
		AlertId = alertId;
	}

	public Alert(Disney.Mix.SDK.Internal.MixDomain.Alert alert)
		: this(alert.Level, alert.Text, alert.AlertId.Value)
	{
	}

	public Alert(AddAlertNotification notification)
		: this(notification.Alert)
	{
	}

	public Alert(AlertDocument doc)
		: this(doc.Level, doc.Type, doc.AlertId)
	{
	}
}
