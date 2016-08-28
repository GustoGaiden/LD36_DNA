using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class HumanSelectPrimaryEvent : GameEvent{

	public PersonVisual visual;
	public HumanSelectPrimaryEvent(PersonVisual visComp)
	{
		visual = visComp;
	}
	
}
