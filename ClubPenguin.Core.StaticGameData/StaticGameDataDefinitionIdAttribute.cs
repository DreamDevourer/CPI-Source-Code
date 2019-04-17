// StaticGameDataDefinitionIdAttribute
using ClubPenguin.Core.StaticGameData;
using System;
using System.Reflection;

public class StaticGameDataDefinitionIdAttribute : Attribute
{
	public static FieldInfo GetAttributedField(Type type)
	{
		FieldInfo[] fields = type.GetFields();
		foreach (FieldInfo fieldInfo in fields)
		{
			object[] customAttributes = fieldInfo.GetCustomAttributes(typeof(StaticGameDataDefinitionIdAttribute), inherit: true);
			if (customAttributes.Length > 0)
			{
				return fieldInfo;
			}
		}
		return null;
	}
}
