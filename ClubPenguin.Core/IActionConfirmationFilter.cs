// IActionConfirmationFilter
using ClubPenguin.Core;
using System;

public interface IActionConfirmationFilter
{
	bool IsActionValid(Type action, object payload);

	void ShowConfirmation(Type action, ActionConfirmationService.FilterCallback callback);

	string GetFilterId();
}
