// IInternalFriend
using Disney.Mix.SDK;

public interface IInternalFriend : IFriend
{
	string Swid
	{
		get;
	}

	void ChangeTrust(bool isTrusted);
}
