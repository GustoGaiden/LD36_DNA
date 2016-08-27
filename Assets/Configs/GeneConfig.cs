using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public class GeneConfig : ScriptableObject
{
	public string Attribute;
	public Vector2 ContainerSize = new Vector2();

	public List<GeneStatusConfig> Types;
	

}


