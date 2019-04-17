// JsonIgnoreAttribute
using JsonFx.Json;
using System;
using System.Reflection;

[AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
public sealed class JsonIgnoreAttribute : Attribute
{
	public static bool IsJsonIgnore(object value)
	{
		if (value == null)
		{
			return false;
		}
		Type type = value.GetType();
		ICustomAttributeProvider customAttributeProvider = null;
		customAttributeProvider = ((!type.IsEnum) ? (value as ICustomAttributeProvider) : type.GetField(Enum.GetName(type, value)));
		if (customAttributeProvider == null)
		{
			throw new ArgumentException();
		}
		return customAttributeProvider.IsDefined(typeof(JsonIgnoreAttribute), inherit: true);
	}

	public static bool IsXmlIgnore(object value)
	{
		if (value == null)
		{
			return false;
		}
		Type type = value.GetType();
		ICustomAttributeProvider customAttributeProvider = null;
		customAttributeProvider = ((!type.IsEnum) ? (value as ICustomAttributeProvider) : type.GetField(Enum.GetName(type, value)));
		if (customAttributeProvider == null)
		{
			throw new ArgumentException();
		}
		return false;
	}
}
