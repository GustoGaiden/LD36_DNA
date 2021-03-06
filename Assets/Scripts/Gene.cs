﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Gene {

	// A Gene is the expression of an individual attribute of a Person
	// It consists of an attribute, and a status.
	// Examples: 
	// Hair : Brown
	// Eyes : Blue
	// Metabolism : Fast

	public string Attribute { get; private set; }
	public string Status { get; private set; }
	public DNAMarker DNAMarker;  // The marker is a permanent string that is generated at staartup.
	public string IndexName { get; private set; }
	public VisualSlotModifier VisualModifierType { get; private set; }
	public string VisualModifierID;


	public Gene(string attribute, string status, VisualSlotModifier modifier, string modID)
	{
		Attribute = attribute;
		Status = status;
		IndexName = Attribute + "::" + Status;
		DNAMarker = new DNAMarker(IndexName);
		VisualModifierType = modifier;
		VisualModifierID = modID;
	}
}