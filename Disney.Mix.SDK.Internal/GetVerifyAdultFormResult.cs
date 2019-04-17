// GetVerifyAdultFormResult
using Disney.Mix.SDK;

public class GetVerifyAdultFormResult : IGetVerifyAdultFormResult
{
	public IVerifyAdultForm Form
	{
		get;
		private set;
	}

	public GetVerifyAdultFormResult(IVerifyAdultForm form)
	{
		Form = form;
	}
}
