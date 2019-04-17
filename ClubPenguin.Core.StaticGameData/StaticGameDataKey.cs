// StaticGameDataKey
using System;

[Serializable]
public class StaticGameDataKey
{
	public static string GetTypeString(Type t)
	{
		return t.FullName + ", " + t.Assembly.GetName().Name;
	}
}
