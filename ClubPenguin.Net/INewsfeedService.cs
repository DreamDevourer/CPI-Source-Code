// INewsfeedService
using ClubPenguin.Net;

public interface INewsfeedService : INetworkService
{
	void GetLatestPostTime(string language);
}
