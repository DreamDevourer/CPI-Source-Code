// ConditionalConfiguration
using ClubPenguin.Configuration;
using Disney.LaunchPadFramework;
using System.Collections.Generic;
using System.Diagnostics;

public class ConditionalConfiguration
{
	private Dictionary<string, ConditionalProperty> properties = new Dictionary<string, ConditionalProperty>();

	public ConditionalConfiguration(ConditionalDefinition[] definitionDataList)
	{
		int num = definitionDataList.Length;
		for (int i = 0; i < num; i++)
		{
			ConditionalDefinition conditionalDefinition = definitionDataList[i];
			properties[conditionalDefinition.name] = conditionalDefinition.GenerateProperty();
		}
	}

	public T Get<T>(string propertyKey, T fallbackValue)
	{
		ConditionalProperty<T> property = GetProperty<T>(propertyKey);
		if (property != null)
		{
			return property.Value;
		}
		Log.LogErrorFormatted(this, "Unable to find Property ({0}), using fallback value: {1}", propertyKey, fallbackValue);
		return fallbackValue;
	}

	[Conditional("QA_BUILD")]
	[Conditional("CI_BUILD")]
	public void Set<T>(string propertyKey, T valueOverride)
	{
		ConditionalProperty<T> property = GetProperty<T>(propertyKey);
		if (property != null)
		{
			property.Value = valueOverride;
		}
	}

	public ConditionalProperty<T> GetProperty<T>(string propertyKey)
	{
		if (properties.TryGetValue(propertyKey, out ConditionalProperty value))
		{
			ConditionalProperty<T> conditionalProperty = value as ConditionalProperty<T>;
			if (conditionalProperty != null)
			{
				return conditionalProperty;
			}
		}
		return null;
	}
}
