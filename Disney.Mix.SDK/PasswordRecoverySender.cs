// PasswordRecoverySender
using DeviceDB;
using Disney.Mix.SDK;
using Disney.Mix.SDK.Internal;
using System;

public class PasswordRecoverySender : Disney.Mix.SDK.IPasswordRecoverySender
{
	private readonly Disney.Mix.SDK.Internal.IPasswordRecoverySender passwordRecoverySender;

	public PasswordRecoverySender(IKeychain keychain, AbstractLogger logger, string localStorageDirPath, string guestControllerHostUrl, string guestControllerSpoofedIpAddress, string oneIdClientId, ICoroutineManager coroutineManager)
	{
		SystemStopwatchFactory stopwatchFactory = new SystemStopwatchFactory();
		SystemWwwFactory wwwFactory = new SystemWwwFactory();
		WwwCallFactory wwwCallFactory = new WwwCallFactory(logger, coroutineManager, stopwatchFactory, wwwFactory);
		FileSystem fileSystem = new FileSystem();
		DatabaseDirectoryCreator directoryCreator = new DatabaseDirectoryCreator(fileSystem, localStorageDirPath);
		DocumentCollectionFactory documentCollectionFactory = new DocumentCollectionFactory();
		SystemRandom random = new SystemRandom();
		DatabaseCorruptionHandler databaseCorruptionHandler = new DatabaseCorruptionHandler(logger, fileSystem, localStorageDirPath);
		SystemEpochTime epochTime = new SystemEpochTime();
		Database database = new Database(keychain.LocalStorageKey, random, epochTime, directoryCreator, documentCollectionFactory, databaseCorruptionHandler);
		GuestControllerClient guestControllerClient = new GuestControllerClient(wwwCallFactory, guestControllerSpoofedIpAddress, database, "NoSWID", guestControllerHostUrl, oneIdClientId, logger);
		passwordRecoverySender = new Disney.Mix.SDK.Internal.PasswordRecoverySender(logger, guestControllerClient);
	}

	public void Send(string lookupValue, string languageCode, Action<ISendPasswordRecoveryResult> callback)
	{
		passwordRecoverySender.Send(lookupValue, languageCode, callback);
	}
}
