// MidiSequencerEvents
using Fabric.MIDI;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MidiSequencerEvents
{
	[SerializeField]
	public List<MidiSequencerEvent> Events = new List<MidiSequencerEvent>();
}
