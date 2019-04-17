// GetCatalogPopularOperation
using ClubPenguin.Net.Client;
using ClubPenguin.Net.Domain;

public class GetCatalogPopularOperation : BaseCatalogSectionOperation<CatalogSectionRequest>
{
	public GetCatalogPopularOperation(CatalogSectionRequest sectionRequest)
		: base(sectionRequest)
	{
		CatalogSection = "popular";
	}
}
