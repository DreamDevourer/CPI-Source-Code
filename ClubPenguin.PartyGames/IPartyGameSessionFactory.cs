// IPartyGameSessionFactory
using ClubPenguin.PartyGames;

public interface IPartyGameSessionFactory
{
	IPartyGameSession getPartyGameSession(PartyGameDefinition.GameTypes type);
}
