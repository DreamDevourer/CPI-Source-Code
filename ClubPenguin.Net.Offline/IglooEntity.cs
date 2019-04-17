// IglooEntity
using ClubPenguin.Net.Domain.Igloo;
using ClubPenguin.Net.Offline;

public struct IglooEntity : IOfflineData
{
	public IglooData Data;

	public void Init()
	{
		Data = new IglooData();
	}
}
