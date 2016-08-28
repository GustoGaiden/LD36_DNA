using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PersonVisual : MonoBehaviour
{

	public Image HeadContainer;
	public Image EyesContainer;
	public Image BodyContainer;
	public Image HairContainer;

	public PersonData Data;

	public PersonVisual()
	{

	}

	public void initialize(PersonData data)
	{
		Data = data;
		updateVisualDisplay();
	}

	private void updateVisualDisplay()
	{
		string sexMod = "";
		string pigmentMod = "";
		string eyeColorMod = "";
		string hairColorMod = "";

		foreach (Gene Attribute in Data.Genes)
		{
			checkAndAssignMod(ref sexMod, VisualSlotModifier.Sex, Attribute);
			checkAndAssignMod(ref pigmentMod, VisualSlotModifier.SkinColor, Attribute);
			checkAndAssignMod(ref eyeColorMod, VisualSlotModifier.EyeColor, Attribute);
			checkAndAssignMod(ref hairColorMod, VisualSlotModifier.HairColor, Attribute);
		}

		string bodyAssetString = sexMod + "_" + pigmentMod + "_body";
		string hairAssetString = sexMod + "_" + hairColorMod + "_hair";
		string eyeAssetString = eyeColorMod + "_eyes";
		string headAssetString = pigmentMod + "_head";

		BodyContainer.sprite = Main.SpriteAtlas[bodyAssetString];
		HairContainer.sprite = Main.SpriteAtlas[hairAssetString];
		EyesContainer.sprite = Main.SpriteAtlas[eyeAssetString];
		HeadContainer.sprite = Main.SpriteAtlas[headAssetString];
	}

	private void checkAndAssignMod(ref string modString, VisualSlotModifier modType, Gene Attribute)
	{
		if (modString != "")
		{
			return;
		}

		if (modType == Attribute.VisualModifierType)
		{
			modString = Attribute.VisualModifierID;
		}
	}



	public void OnPersonClicked()
	{
		Main.eventManager.TriggerEvent(new HumanSelectPrimaryEvent(this));
	}
}

public enum VisualSlotModifier
{
	None,
	SkinColor,
	Sex,
	HairColor,
	EyeColor
	
}
