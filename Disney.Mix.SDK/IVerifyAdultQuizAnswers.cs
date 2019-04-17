// IVerifyAdultQuizAnswers
using Disney.Mix.SDK;
using System.Collections.Generic;

public interface IVerifyAdultQuizAnswers
{
	string Id
	{
		get;
	}

	IDictionary<IVerifyAdultQuestion, string> Answers
	{
		get;
	}
}
