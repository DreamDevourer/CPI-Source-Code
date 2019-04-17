// MidiSequencerEvent
using Fabric;
using Fabric.MIDI;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MidiSequencerEvent
{
	[SerializeField]
	public Fabric.Component component;

	[NonSerialized]
	public List<MidiEvent> Events = new List<MidiEvent>();
}
