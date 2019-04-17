// IMixWebCallQueue
using Disney.Mix.SDK.Internal;
using Disney.Mix.SDK.Internal.MixDomain;

public interface IMixWebCallQueue
{
	void AddWebCall<TRequest, TResponse>(IWebCall<TRequest, TResponse> webCall) where TRequest : BaseUserRequest where TResponse : BaseResponse, new();

	void RemoveWebCall<TRequest, TResponse>(IWebCall<TRequest, TResponse> webCall) where TRequest : BaseUserRequest where TResponse : BaseResponse, new();

	void HandleRefreshing();

	void HandleGuestControllerTokenRefreshSuccess(string guestControllerAccessToken);

	void HandleGuestControllerTokenRefreshFailure();

	void HandleSessionRefreshSuccess(IWebCallEncryptor encryptor);

	void HandleSessionRefreshFailure();

	void HandleCombinedRefreshSuccess(string guestControllerAccessToken, IWebCallEncryptor encryptor);
}
