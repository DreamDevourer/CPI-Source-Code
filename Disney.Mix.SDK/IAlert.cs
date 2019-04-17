// IAlert
using Disney.Mix.SDK;

public interface IAlert
{
	int Level
	{
		get;
	}

	AlertType Type
	{
		get;
	}
}
