// SmartFoxCommand
using ClubPenguin.Net.Client.Smartfox;
using System;
using System.Collections.Generic;

public static class SmartFoxCommand
{
	private static Dictionary<string, SmartfoxCommand> enumMap;

	private static List<SmartfoxCommand> enumList;

	static SmartFoxCommand()
	{
		enumMap = new Dictionary<string, SmartfoxCommand>();
		enumList = new List<SmartfoxCommand>();
		foreach (SmartfoxCommand value in Enum.GetValues(typeof(SmartfoxCommand)))
		{
			enumMap.Add(value.GetCommand(), value);
			enumList.Add(value);
		}
	}

	public static SmartfoxCommand? FromString(string str)
	{
		if (!enumMap.ContainsKey(str))
		{
			return null;
		}
		return enumMap[str];
	}

	public static List<SmartfoxCommand> Values()
	{
		return enumList;
	}
}
