// ProxyComponent
using Fabric;
using UnityEngine;

[AddComponentMenu("Fabric/Components/ProxyComponent")]
public class ProxyComponent : Fabric.Component
{
	[SerializeField]
	public Fabric.Component targetComponment;

	public void Awake()
	{
		if (targetComponment != null)
		{
			targetComponment.MoveToComponent(this);
		}
	}
}
