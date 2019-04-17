// CollectiblesData
#define UNITY_ASSERTIONS
using ClubPenguin;
using ClubPenguin.Analytics;
using Disney.Kelowna.Common.DataModel;
using Disney.MobileNetwork;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

[Serializable]
public class CollectiblesData : ScopedData
{
	private Dictionary<string, int> collectibleTotals;

	private Dictionary<string, int> collectibleTotalsForAnalytics = new Dictionary<string, int>();

	private bool isLogged;

	public Dictionary<string, int> CollectibleTotals
	{
		get
		{
			if (collectibleTotals == null)
			{
				collectibleTotals = new Dictionary<string, int>();
			}
			return collectibleTotals;
		}
		internal set
		{
			if (value != null)
			{
				collectibleTotals = new Dictionary<string, int>(value);
			}
			else
			{
				collectibleTotals = new Dictionary<string, int>();
			}
		}
	}

	protected override string scopeID => CPDataScopes.Session.ToString();

	protected override Type monoBehaviourType => typeof(CollectiblesDataMonoBehaviour);

	public event Action<string, int> OnCollectiblesAdded;

	public event Action<string, int> OnCollectiblesRemoved;

	protected override void notifyWillBeDestroyed()
	{
		this.OnCollectiblesAdded = null;
		this.OnCollectiblesRemoved = null;
		logExchangeData();
	}

	public void AddCollectible(string name, int amount)
	{
		Debug.Assert(amount >= 0);
		Debug.Assert(name != "");
		amount = Mathf.Abs(amount);
		if (!collectibleTotals.ContainsKey(name))
		{
			collectibleTotals[name] = amount;
		}
		else
		{
			Dictionary<string, int> dictionary;
			string key;
			(dictionary = collectibleTotals)[key = name] = dictionary[key] + amount;
		}
		if (!collectibleTotalsForAnalytics.ContainsKey(name))
		{
			collectibleTotalsForAnalytics[name] = amount;
		}
		else
		{
			Dictionary<string, int> dictionary;
			string key;
			(dictionary = collectibleTotalsForAnalytics)[key = name] = dictionary[key] + amount;
		}
		if (this.OnCollectiblesAdded != null)
		{
			this.OnCollectiblesAdded(name, amount);
		}
		sendCollectibleEvents(name, -amount);
	}

	public void RemoveCollectible(string name, int amount)
	{
		Debug.Assert(amount >= 0);
		Debug.Assert(name != "");
		amount = Mathf.Abs(amount);
		if (collectibleTotals.ContainsKey(name))
		{
			Dictionary<string, int> dictionary;
			string key;
			(dictionary = collectibleTotals)[key = name] = dictionary[key] - amount;
			if (collectibleTotals[name] < 0)
			{
				amount = collectibleTotals[name];
				collectibleTotals[name] = 0;
			}
			sendCollectibleEvents(name, -amount);
		}
	}

	public int GetCollectibleTotal(string name)
	{
		if (!collectibleTotals.ContainsKey(name))
		{
			return 0;
		}
		return collectibleTotals[name];
	}

	private void sendCollectibleEvents(string name, int amount)
	{
		if (amount > 0 && this.OnCollectiblesAdded != null)
		{
			this.OnCollectiblesAdded(name, amount);
		}
		if (amount < 0 && this.OnCollectiblesRemoved != null)
		{
			this.OnCollectiblesRemoved(name, Math.Abs(amount));
		}
	}

	private void logExchangeData()
	{
		if (!isLogged && collectibleTotalsForAnalytics.Count != 0)
		{
			isLogged = true;
			StringBuilder stringBuilder = new StringBuilder();
			foreach (KeyValuePair<string, int> collectibleTotalsForAnalytic in collectibleTotalsForAnalytics)
			{
				stringBuilder.Append($"{collectibleTotalsForAnalytic.Key}={collectibleTotalsForAnalytic.Value}|");
			}
			Service.Get<ICPSwrveService>().Action("collectible_inventory", stringBuilder.ToString());
		}
	}
}
