// IGuestControllerClientFactory
using Disney.Mix.SDK.Internal;

public interface IGuestControllerClientFactory
{
	IGuestControllerClient Create(string swid);
}
