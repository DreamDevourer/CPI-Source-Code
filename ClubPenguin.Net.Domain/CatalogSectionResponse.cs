// CatalogSectionResponse
using ClubPenguin.Net.Domain;
using System.Collections.Generic;

public struct CatalogSectionResponse
{
	public string cursor;

	public List<CatalogItemData> items;
}
