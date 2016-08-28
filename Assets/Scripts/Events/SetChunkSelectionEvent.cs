using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class SetChunkSelectionEvent : GameEvent
{
	public DNAChunk selectedChunk;

	public SetChunkSelectionEvent(DNAChunk selected)
	{
		selectedChunk = selected;
	}
}

