// TubeData
using ClubPenguin;
using Disney.Kelowna.Common.DataModel;
using System;
using UnityEngine;

[Serializable]
public class TubeData : BaseData
{
	[SerializeField]
	private int selectedTubeId;

	public int SelectedTubeId
	{
		get
		{
			return selectedTubeId;
		}
		set
		{
			if (selectedTubeId != value)
			{
				selectedTubeId = value;
				if (this.OnTubeSelected != null)
				{
					this.OnTubeSelected(selectedTubeId);
				}
			}
		}
	}

	protected override Type monoBehaviourType => typeof(TubeDataMonoBehaviour);

	public event Action<int> OnTubeSelected;

	protected override void notifyWillBeDestroyed()
	{
		this.OnTubeSelected = null;
	}
}
