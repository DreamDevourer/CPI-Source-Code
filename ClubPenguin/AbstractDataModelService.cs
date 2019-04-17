// AbstractDataModelService
using ClubPenguin.Core;
using UnityEngine;

public class AbstractDataModelService : MonoBehaviour
{
	protected CPDataEntityCollection dataEntityCollection;

	public void SetDataEntityCollection(CPDataEntityCollection dataEntityCollection)
	{
		this.dataEntityCollection = dataEntityCollection;
	}
}
