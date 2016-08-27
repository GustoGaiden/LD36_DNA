using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public class GeneConfig : ScriptableObject
{
	public string Attribute;
	public VisualSlotModifier VisualModifierSlot;
	public List<GeneStatusConfig> Types;
	

}


