// DictionaryUtils
using System.Collections.Generic;

public static class DictionaryUtils
{
	public static TValue TryGetValue<TKey, TValue>(IDictionary<TKey, TValue> dictionary, TKey key)
	{
		if (dictionary == null)
		{
			return default(TValue);
		}
		dictionary.TryGetValue(key, out TValue value);
		return value;
	}
}
