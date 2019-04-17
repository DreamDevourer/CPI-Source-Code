// IVerifyAdultQuestion
using System.Collections.Generic;

public interface IVerifyAdultQuestion
{
	int QuestionId
	{
		get;
	}

	string QuestionText
	{
		get;
	}

	IEnumerable<string> Choices
	{
		get;
	}
}
