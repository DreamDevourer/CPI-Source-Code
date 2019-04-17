// UserStatsResponse
using ClubPenguin.Net.Domain;
using System.Collections.Generic;

public struct UserStatsResponse
{
	public long totalItemsSold;

	public long totalItemsPurchased;

	public CatalogItemData mostPopularItem;

	public List<CatalogItemData> currentItems;
}
