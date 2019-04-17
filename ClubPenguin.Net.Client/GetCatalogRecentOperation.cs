// GetCatalogRecentOperation
using ClubPenguin.Net.Client;
using ClubPenguin.Net.Domain;

public class GetCatalogRecentOperation : BaseCatalogSectionOperation<CatalogSectionRequest>
{
	public GetCatalogRecentOperation(CatalogSectionRequest sectionRequest)
		: base(sectionRequest)
	{
		CatalogSection = "recent";
	}
}
