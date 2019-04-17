// ResumeSessionResult
using Disney.Mix.SDK;

public class ResumeSessionResult : IResumeSessionResult
{
	public bool Success
	{
		get;
		private set;
	}

	public ResumeSessionResult(bool success)
	{
		Success = success;
	}
}
