// IGeolocationGetter
using Disney.Mix.SDK;
using System;

public interface IGeolocationGetter
{
	void Get(Action<IGetGeolocationResult> callback);
}
