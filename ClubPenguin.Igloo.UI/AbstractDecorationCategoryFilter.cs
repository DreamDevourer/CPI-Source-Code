// AbstractDecorationCategoryFilter
using ClubPenguin.DecorationInventory;
using System.Collections.Generic;

public abstract class AbstractDecorationCategoryFilter
{
	protected readonly Dictionary<int, DecorationDefinition> dictionaryOfDecorationDefinitions;

	protected readonly DecorationInventoryService decorationInventoryService;

	public AbstractDecorationCategoryFilter(Dictionary<int, DecorationDefinition> dictionaryOfDecorationDefinitions, DecorationInventoryService decorationInventoryService)
	{
		this.dictionaryOfDecorationDefinitions = dictionaryOfDecorationDefinitions;
		this.decorationInventoryService = decorationInventoryService;
	}

	internal abstract List<KeyValuePair<DecorationDefinition, int>> GetDefinitionsToDisplay();
}
