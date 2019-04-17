// IVerifyAdultQuiz
using Disney.Mix.SDK;
using System.Collections.Generic;

public interface IVerifyAdultQuiz
{
	IEnumerable<IVerifyAdultQuestion> Questions
	{
		get;
	}

	string Id
	{
		get;
	}
}
