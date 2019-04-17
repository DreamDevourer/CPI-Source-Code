// GetCatalogFriendsOperation
using ClubPenguin.Net.Client;
using ClubPenguin.Net.Domain;

public class GetCatalogFriendsOperation : BaseCatalogSectionOperation<CatalogSectionRequest>
{
	public GetCatalogFriendsOperation(CatalogSectionRequest sectionRequest)
		: base(sectionRequest)
	{
		CatalogSection = "friends";
	}
}
