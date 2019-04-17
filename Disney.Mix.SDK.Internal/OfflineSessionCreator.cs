// OfflineSessionCreator
using DeviceDB;
using Disney.Mix.SDK;
using Disney.Mix.SDK.Internal;
using System;

public class OfflineSessionCreator : IOfflineSessionCreator
{
	private readonly AbstractLogger logger;

	private readonly ISessionFactory sessionFactory;

	private readonly IDatabase database;

	public OfflineSessionCreator(AbstractLogger logger, ISessionFactory sessionFactory, IDatabase database)
	{
		this.logger = logger;
		this.sessionFactory = sessionFactory;
		this.database = database;
	}

	public IInternalOfflineLastSessionResult Create()
	{
		try
		{
			SessionDocument lastLoggedInSessionDocument = database.GetLastLoggedInSessionDocument();
			if (lastLoggedInSessionDocument == null)
			{
				return new OfflineLastSessionNotFoundResult();
			}
			IInternalSession session = sessionFactory.Create(lastLoggedInSessionDocument.Swid);
			return new OfflineLastSessionResult(success: true, session);
		}
		catch (CorruptionException arg)
		{
			logger.Fatal("Corruption detected during offline session creation: " + arg);
			return new OfflineLastSessionCorruptionDetectedResult();
		}
		catch (Exception arg2)
		{
			logger.Critical("Error creating session: " + arg2);
			return new OfflineLastSessionResult(success: false, null);
		}
	}
}
