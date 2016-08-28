using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class HumanSelectSecondaryEvent : GameEvent
{
	public PersonVisual visual;
	public HumanSelectSecondaryEvent(PersonVisual visComp)
	{
		visual = visComp;
	}

}
