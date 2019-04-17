// ServiceWrapper<T>
using Disney.MobileNetwork;

internal class ServiceWrapper<T> : IServiceWrapper
{
	public static T instance = default(T);

	public object Instance => instance;

	public void Unset()
	{
		instance = default(T);
	}
}
