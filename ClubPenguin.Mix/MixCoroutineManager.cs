// MixCoroutineManager
using Disney.Kelowna.Common;
using Disney.LaunchPadFramework;
using Disney.Mix.SDK;
using Disney.MobileNetwork;
using System.Collections;
using System.Collections.Generic;

internal class MixCoroutineManager : ICoroutineManager
{
	private Dictionary<IEnumerator, ICoroutine> activeCoroutines = new Dictionary<IEnumerator, ICoroutine>();

	public void Start(IEnumerator enumerator)
	{
		activeCoroutines.Add(enumerator, CoroutineRunner.StartPersistent(enumerator, this, "MixCoroutine"));
	}

	public void Stop(IEnumerator enumerator)
	{
		if (activeCoroutines.TryGetValue(enumerator, out ICoroutine value))
		{
			value.Cancel();
			return;
		}
		Service.Get<CoroutineRunner>().StopCoroutine(enumerator);
		Log.LogError(this, "Attempted to stop a mix coroutine that was not started via MixCoroutineManager. This may indicate that there is a bug in the Mix SDK.");
	}
}
