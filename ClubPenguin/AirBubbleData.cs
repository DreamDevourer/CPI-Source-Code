// AirBubbleData
using ClubPenguin;
using ClubPenguin.Net.Domain;
using Disney.Kelowna.Common.DataModel;
using System;

[Serializable]
public class AirBubbleData : ScopedData
{
	private AirBubble airBubble;

	public AirBubble AirBubble
	{
		get
		{
			return airBubble;
		}
		set
		{
			if (value != airBubble)
			{
				valueChanged(value);
				airBubble = value;
			}
		}
	}

	protected override string scopeID => CPDataScopes.Zone.ToString();

	protected override Type monoBehaviourType => typeof(AirBubbleDataMonoBehaviour);

	public event Action<AirBubble> AirBubbleChanged;

	protected override void notifyWillBeDestroyed()
	{
		this.AirBubbleChanged = null;
	}

	private void valueChanged(AirBubble value)
	{
		if (this.AirBubbleChanged != null)
		{
			this.AirBubbleChanged(value);
		}
	}
}
