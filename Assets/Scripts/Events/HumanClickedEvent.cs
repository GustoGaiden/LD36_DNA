using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class HumanClickedEvent : GameEvent{

	public PersonVisual visual;
	public HumanClickedEvent(PersonVisual visComp)
	{
		visual = visComp;
	}
	
}
