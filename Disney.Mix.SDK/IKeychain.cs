// IKeychain
public interface IKeychain
{
	byte[] LocalStorageKey
	{
		get;
	}

	byte[] PushNotificationKey
	{
		set;
	}
}
