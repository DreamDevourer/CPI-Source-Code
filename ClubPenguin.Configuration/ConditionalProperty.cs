// ConditionalProperty
public abstract class ConditionalProperty
{
	public const string LOGGED_PROPERTIES_KEY_FORMAT = "cp.ConditionalPropertyLogged.{0}";

	public string AnalyticsTierName = "default";

	public string Key
	{
		get;
		protected set;
	}

	public abstract string ValueToString();
}
