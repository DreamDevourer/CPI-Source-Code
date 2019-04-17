// ParentGate
using ClubPenguin.Analytics;
using ClubPenguin.ContentGates;
using Disney.Kelowna.Common;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using System;

public class ParentGate : AbstractGateController
{
	private PrefabContentKey gateContentKey = new PrefabContentKey("ParentGatePrefabs/ParentGatePopupPrefab");

	private ParentGateGenerator parentQuestion;

	private int errorCount;

	protected override PrefabContentKey GateContentKey => gateContentKey;

	protected override void prepGate()
	{
		Service.Get<ICPSwrveService>().Action("view.parent_gate");
		try
		{
			parentQuestion = new ParentGateGenerator();
			errorCount = 0;
			parentQuestion.resetQuestion();
			gatePrefabController.QuestionText.text = parentQuestion.getQuestion();
			gatePrefabController.InstructionsText.text = parentQuestion.getInstructions();
		}
		catch (Exception ex)
		{
			Log.LogException(this, ex);
			Log.LogErrorFormatted(this, "Missing key elements from parent gate prefab\n QuestionText: {1}\n InstructionsText: {3}", gatePrefabController.QuestionText, gatePrefabController.InstructionsText);
			Return();
		}
	}

	protected override void onValueChanged(string strAnswer)
	{
		if (strAnswer.Length == 4)
		{
			onSubmitClicked();
		}
	}

	protected override void onSubmitClicked()
	{
		string text = gatePrefabController.AnswerInputField.text;
		if (int.TryParse(text, out int result) && parentQuestion.checkAnswer(result))
		{
			Service.Get<ICPSwrveService>().Action("game.parent_gate", "passed");
			handleGateSuccess();
			return;
		}
		errorCount++;
		if (errorCount >= 3)
		{
			Service.Get<ICPSwrveService>().Action("game.parent_gate", "failed");
			handleGateFailure();
		}
		else
		{
			gatePrefabController.ErrorIcon.gameObject.SetActive(value: true);
		}
	}

	protected override string getAnalyticsContext()
	{
		return "parent_gate";
	}
}
