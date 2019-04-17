// IModerationAlert
using Disney.Mix.SDK;

public interface IModerationAlert
{
	bool IsCritical
	{
		get;
	}

	string Text
	{
		get;
	}

	IAlert MixAlert
	{
		get;
	}
}
