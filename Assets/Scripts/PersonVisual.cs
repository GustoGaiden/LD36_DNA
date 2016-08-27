using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PersonVisual : MonoBehaviour {

	public Image HeadContainer;
	public Image EyesContainer;
	public Image BodyContainer;
	public Image HairContainer;
	public PersonData Data;

	public PersonVisual(PersonData data)
	{
		Data = data;
		


	}

	private void setBodySprite()
	{
		foreach (Gene Attribute in Data.Genes)
		{
			if(Attribute.VisualModifierType == VisualSlotModifier.HairColor)
			{
			
				
			}
		}
	}


	
}

public enum VisualSlotModifier
{
	SkinColor,
	Sex,
	HairColor,
	EyeColor
}
