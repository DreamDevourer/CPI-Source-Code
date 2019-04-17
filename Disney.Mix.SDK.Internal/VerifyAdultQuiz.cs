// VerifyAdultQuiz
using Disney.Mix.SDK;
using System.Collections.Generic;

public class VerifyAdultQuiz : IVerifyAdultQuiz
{
	public IEnumerable<IVerifyAdultQuestion> Questions
	{
		get;
		private set;
	}

	public string Id
	{
		get;
		private set;
	}

	public VerifyAdultQuiz(IEnumerable<IVerifyAdultQuestion> questions, string id)
	{
		Questions = questions;
		Id = id;
	}
}
