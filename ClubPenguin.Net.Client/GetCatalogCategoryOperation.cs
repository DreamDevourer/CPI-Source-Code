// GetCatalogCategoryOperation
using ClubPenguin.Net.Client;
using ClubPenguin.Net.Domain;
using hg.ApiWebKit.mappers;

public class GetCatalogCategoryOperation : BaseCatalogSectionOperation<CatalogCategoryRequest>
{
	[HttpRequestJsonBody(VariableName = "category")]
	public int Category;

	public GetCatalogCategoryOperation(CatalogCategoryRequest categoryRequest)
		: base(categoryRequest)
	{
		CatalogSection = "category";
	}
}
