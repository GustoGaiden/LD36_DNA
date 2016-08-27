using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public class HumanSpriteAtlasConfig : ScriptableObject {

	public List<SpriteIdentifier> SpriteAtlas = new List<SpriteIdentifier>();
}
