// InputInfo
using ClubPenguin.Input;
using DevonLocalization.Core;
using Disney.MobileNetwork;
using UnityEngine;

public abstract class InputInfo
{
	public abstract void Populate(ControlScheme controlScheme);

	protected string getKeyCodeTranslation(KeyCode keyCode)
	{
		if (keyCode == KeyCode.None)
		{
			return string.Empty;
		}
		string key = $"Input.KeyCodes.{keyCode}";
		string value;
		return Service.Get<Localizer>().tokens.TryGetValue(key, out value) ? value : keyCode.ToString();
	}
}
