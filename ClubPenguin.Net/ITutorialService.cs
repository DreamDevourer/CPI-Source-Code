// ITutorialService
using ClubPenguin.Net;
using ClubPenguin.Net.Domain;

public interface ITutorialService : INetworkService
{
	void SetTutorial(Tutorial tutorial);
}
