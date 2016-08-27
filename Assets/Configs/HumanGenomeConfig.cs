using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable]
public class HumanGenomeConfig : ScriptableObject{

	public List<GeneConfig> HumanGenome = new List<GeneConfig>();
}
