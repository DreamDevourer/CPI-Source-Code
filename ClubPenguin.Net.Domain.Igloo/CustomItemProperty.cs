// CustomItemProperty
using System;

[Serializable]
public struct CustomItemProperty
{
	public string customName;

	public string customType;

	public object customValue;

	public override string ToString()
	{
		return $"Name: {customName}, Type: {customType}, Value: {customValue}";
	}
}
