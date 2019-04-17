// AllMyIglooDecorationCategoryFilter
using ClubPenguin.Core;
using ClubPenguin.DecorationInventory;
using ClubPenguin.Igloo.UI;
using ClubPenguin.SceneManipulation;
using System.Collections.Generic;

internal class AllMyIglooDecorationCategoryFilter : AbstractDecorationCategoryFilter
{
	public AllMyIglooDecorationCategoryFilter(Dictionary<int, DecorationDefinition> dictionaryOfDecorationDefinitions, DecorationInventoryService decorationInventoryService)
		: base(dictionaryOfDecorationDefinitions, decorationInventoryService)
	{
	}

	internal override List<KeyValuePair<DecorationDefinition, int>> GetDefinitionsToDisplay()
	{
		return SceneRefs.Get<SceneManipulationService>().GetAvailableDecorations();
	}
}
